using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Amazon.CDK.AWS.S3;
using CdkTest.NestedStacks;
using Constructs;

namespace CdkTest.Stacks
{
    public class HelloStack : Stack
    {
        internal HelloStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            //_ = new LogGroup(this, "Levi-HelloStack-LogGroup", new LogGroupProps
            //{
            //    LogGroupName = "Levi-HelloStack-LogGroup",
            //    Retention = RetentionDays.ONE_DAY,
            //    RemovalPolicy = RemovalPolicy.DESTROY
            //});

            //_ = new HelloNestedStack(this);
            
            var bucket = new Bucket(this, "AAALeviTest", new BucketProps
            {
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
                Encryption = BucketEncryption.S3_MANAGED,
                RemovalPolicy = RemovalPolicy.DESTROY,
                AutoDeleteObjects = true
            });

            bucket.AddLifecycleRule(new LifecycleRule()
            {
                Prefix= "abc123/",
                Expiration = Duration.Days(1),
                AbortIncompleteMultipartUploadAfter = Duration.Days(1),
            });
        }
    }
}
