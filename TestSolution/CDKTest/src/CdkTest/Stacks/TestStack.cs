using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using CdkTest.NestedStacks;
using Constructs;

namespace CdkTest.Stacks
{
    public class TestStack : Stack
    {
        internal TestStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            _ = new LogGroup(this, "Levi-TestStack-LogGroup", new LogGroupProps
            {
                LogGroupName = "Levi-TestStack-LogGroup",
                Retention = RetentionDays.ONE_DAY,
                RemovalPolicy = RemovalPolicy.DESTROY
            });

            _ = new TestNestedStack(this);
        }
    }
}
