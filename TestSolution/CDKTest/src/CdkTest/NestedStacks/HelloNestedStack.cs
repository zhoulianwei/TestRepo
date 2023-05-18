using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdkTest.NestedStacks
{
    public class HelloNestedStack : NestedStack
    {
        public HelloNestedStack(Construct scope) : base(scope, "Levi-HelloStack-NestedStack")
        {
            _ = new LogGroup(this, "Levi-HelloStack-NestedStack-LogGroup", new LogGroupProps
            {
                LogGroupName = "Levi-HelloStack-NestedStack-LogGroup",
                Retention = RetentionDays.ONE_DAY,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
        }
    }
}
