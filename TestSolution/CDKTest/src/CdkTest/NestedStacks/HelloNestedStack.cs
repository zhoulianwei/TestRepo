using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Amazon.CDK.AWS.S3;
using Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdkTest.NestedStacks
{
    public class HelloNestedStack : NestedStack
    {
        public HelloNestedStack(Construct scope) : base(scope, "Levi-HelloStack-NestedStack")
        {
            //_ = new LogGroup(this, "Levi-HelloStack-NestedStack-LogGroup", new LogGroupProps
            //{
            //    LogGroupName = "Levi-HelloStack-NestedStack-LogGroup",
            //    Retention = RetentionDays.ONE_DAY,
            //    RemovalPolicy = RemovalPolicy.DESTROY
            //});

            var domain = "dev.vigilcloud.3xlogic.com";
            var bucket = new Bucket(this, "levi-cors-test");

            var corsRule = new CorsRule
            {
                AllowedHeaders = new[] { "*" },
                AllowedMethods = new[] { HttpMethods.GET },
                AllowedOrigins = new[]
                {
                    $"https://{domain}",
                    $"http://{domain}",
                }
            };

            if (domain == "dev.vigilcloud.3xlogic.com") corsRule.AllowedOrigins = corsRule.AllowedOrigins.Append("http://localhost:8080").ToArray();

            bucket.AddCorsRule(corsRule);
        }
    }
}
