using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdkTest.NestedStacks
{
    public class TestNestedStack : NestedStack
    {
        public TestNestedStack(Construct scope) : base(scope, "Levi-TestStack-NestedStack")
        {
            _ = new LogGroup(this, "Levi-TestStack-NestedStack-LogGroup", new LogGroupProps
            {
                LogGroupName = "Levi-TestStack-NestedStack-LogGroup",
                Retention = RetentionDays.ONE_DAY,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
        }
    }
}
