using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;
using System.Resources;
using System.Reflection;
using ConsoleTest.Resources;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace ConsoleTest
{

    public class People
    {
        public bool? IsStudent { get; set; }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "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";
            var from = "levi.zhou@sbdinc.com";
            var to = "levi.zhou@securitas.com";
            var templateId = "d-c9b69d1c930a4fbba94a43f280d0d26d";
            var props = new Dictionary<string, string>()
                    {
                        {"subject","levi'<>&s superadmin  subject"},
                        {"notificationSubjectSeparator","-"},
                        {"notificationLocationName","End"}
                    };


            var client = new SendGridClient(apiKey);
            var msg = MailHelper.CreateSingleTemplateEmail(
                new EmailAddress(from),
                new EmailAddress(to),
                templateId,
                props);

            var response = client.SendEmailAsync(msg).Result;
            Console.WriteLine(response.StatusCode);
        }


        public static SendGridMessage CreateSingleTemplateEmail(EmailAddress from, EmailAddress to, string templateId, object dynamicTemplateData)
        {
            if (string.IsNullOrWhiteSpace(templateId))
            {
                throw new ArgumentException("templateId is required when creating a dynamic template email.", "templateId");
            }

            SendGridMessage sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(from);
            sendGridMessage.AddTo(to);
            sendGridMessage.TemplateId = templateId;
            if (dynamicTemplateData != null)
            {
                sendGridMessage.SetTemplateData(dynamicTemplateData);
            }

            return sendGridMessage;
        }

        public void InvokeLambda()
        {

            //Console.WriteLine("Hello World!");
            //var awsAccessKeyId = "ASIAWY3BNF3KFX2SXQ6D";
            //var awsSecretAccessKey = "CV8OzhaOULkAEGKyqO1OHIpK/pbBK6uZHrwDqwYq";
            //var awsSessionToken = "IQoJb3JpZ2luX2VjEE4aCXVzLWVhc3QtMSJIMEYCIQCKpKK1T5UM1CEehRHPS6rBUwuHqJgr4Ai5N4V6ufaxlQIhAM0eUsqoKLxjdiJQbm9VqbfZVYgjU8T4jC3L7sIjdyUcKpYDCOf//////////wEQAxoMNDY1NjcxMzY4NDA0IgzkYIFzYd6jyNEbwJ0q6gIvRsNVtUeTT7dvk6oo1Er0mkqGJ8qD0ndPpciJNsTQ8I97jipL6KcLhlSdlsL/9zM5+6lS+UNPD65BiNVeoLL9DEnuucOqoa4E621WG/WXuVCbJ6zMsgpUKySYp+OFRjj35y1mOYVdR+KSe9525D2jeVabmts7NGhREqSseRVKLeBd0aod2nW6vMlBYZzqOqK4EQhrAovybJuEPJpWVuiuwZpQfSfiEbI1LCjrol0e1zKum+2qD2YC1AEK/opluJBybdqf//uVEDyhQ68VC9vRH/4gOHjTn/I820lQaYqbnqF7ql1gOKuHdhluj/gVHkzakKdAlpP5Sccb6I/ah2KJCVr1qAe4TKgfrMdAPeOHVrMhrTJmjNHyK5IHfHW0eSShE83r4Aa//ZUYjC4NjbeOI9OLlzZ+iEKkZTGc8RHGDGoQfXr+tzSJx2Fk1jD19arBy52XdQWUtsiv/2L+lk5Jq0+POVjJgZTFkDC006emBjqlAbRu/KQd3yIGPAI6F081jZXH6ZUb6bQYM+wIEMqH1Tyjf/y/AOFfPmHyqaT7oq9k5lqi1uqAsVwzLyXgP/jM3OSrTANfVSgDPZ5H1Eoq0HF7rGQBxwcwTeJlOSMVUc9JWGkWIXKJQ/Snxk6BzZEbivRyptZ4IsoFw6x/MPcGU4p8USV6eeLha8bvFsWHMvOSAhAFL+674j2RAO40VZtbtHAVAdWQ7A==";
            //var credentials = new SessionAWSCredentials(awsAccessKeyId, awsSecretAccessKey, awsSessionToken);

            //AmazonLambdaClient lambdaClient = new AmazonLambdaClient(credentials);

            //string functionName = "levi-camerauploadbandwidthtestjob";
            //functionName = "VigilCloudCompute-BandwidthTestCameraUploadBandwid-758i7wpG6936";

            //int deviceId = 5450;
            //var payload = $"{deviceId}";
            //Console.WriteLine(payload);

            //var request = new Amazon.Lambda.Model.InvokeRequest
            //{
            //    FunctionName = functionName,
            //    Payload = JsonConvert.SerializeObject(payload),
            //    InvocationType = Amazon.Lambda.InvocationType.Event
            //};

            //Console.WriteLine(request.Payload);

            //lambdaClient.InvokeAsync(request).Wait();

            //Console.WriteLine("End");
        }

        public class Animal
        {
            public void Run()
            {
                Console.WriteLine("I can run");
            }
        }
        public class Bird
        {
            public new void Run()
            {
                Console.WriteLine("I can fly");
            }
        }

    }
}
