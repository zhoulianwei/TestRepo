using Amazon.Runtime;
using System;
using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using Amazon.Lambda;
using Amazon.Lambda.Core;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Newtonsoft.Json;


namespace S3Test
{

    internal class Program
    {

        static void Main(string[] args)
        {

        }

        public static async Task<long> CalculateTotalSize(AmazonS3Client s3client, string bucketName, string prefix)
        {
            long totalSize = 0;

            var listRequest = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = prefix
            };

            do
            {
                ListObjectsV2Response listResponse = await s3client.ListObjectsV2Async(listRequest);

                foreach (var s3Object in listResponse.S3Objects)
                {
                    totalSize += s3Object.Size;
                }

                listRequest.ContinuationToken = listResponse.NextContinuationToken;

            } while (listRequest.ContinuationToken != null);

            return totalSize;
        }

        private static async Task UploadObjectFromFileAsync(IAmazonS3 client, string bucketName, string objectName, string filePath)
        {

            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectName,
                FilePath = filePath,
                ContentType = "text/plain",
            };

            putRequest.Metadata.Add("x-amz-meta-title", "someTitle");

            PutObjectResponse response = await client.PutObjectAsync(putRequest);
        }

        private static async Task UploadLargeFile(string bucketName, string objectKey, string filePath, AmazonS3Client s3Client)
        {
            List<UploadPartResponse> uploadResponses = new();

            var ChunkSize = 5 * 1024 * 1024; // 5MB

            long fileSize = new FileInfo(filePath).Length;

            InitiateMultipartUploadRequest initiateRequest = new InitiateMultipartUploadRequest
            {
                BucketName = bucketName,
                Key = objectKey
            };

            InitiateMultipartUploadResponse initiateResponse = await s3Client.InitiateMultipartUploadAsync(initiateRequest);

            using (var fileStream = File.OpenRead(filePath))
            {
                long uploadedBytes = 0;
                int partNumber = 1;
                byte[] buffer = new byte[ChunkSize];
                int i = 0;
                while (uploadedBytes < fileSize)
                {
                    Console.WriteLine(i++.ToString());
                    int bytesRead = await fileStream.ReadAsync(buffer, 0, ChunkSize);

                    UploadPartRequest uploadRequest = new UploadPartRequest
                    {
                        BucketName = bucketName,
                        Key = objectKey,
                        UploadId = initiateResponse.UploadId,
                        PartNumber = partNumber,
                        InputStream = new MemoryStream(buffer, 0, bytesRead)
                    };

                    UploadPartResponse uploadResponse = await s3Client.UploadPartAsync(uploadRequest);
                    uploadResponses.Add(uploadResponse);

                    uploadedBytes += bytesRead;
                    partNumber++;
                }
            }

            CompleteMultipartUploadRequest completeRequest = new CompleteMultipartUploadRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                UploadId = initiateResponse.UploadId
            };
            completeRequest.AddPartETags(uploadResponses);

            await s3Client.CompleteMultipartUploadAsync(completeRequest);
        }




    }
}
