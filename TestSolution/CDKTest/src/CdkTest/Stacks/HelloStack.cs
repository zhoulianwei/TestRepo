using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using CdkTest.NestedStacks;
using Constructs;

namespace CdkTest.Stacks
{
    public class HelloStack : Stack
    {
        internal HelloStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            _ = new LogGroup(this, "Levi-HelloStack-LogGroup", new LogGroupProps
            {
                LogGroupName = "Levi-HelloStack-LogGroup",
                Retention = RetentionDays.ONE_DAY,
                RemovalPolicy = RemovalPolicy.DESTROY
            });

            _ = new HelloNestedStack(this);
        }
    }
}
