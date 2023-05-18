using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Constructs;

namespace CdkTest.Stacks
{
    public class HelloStack : Stack
    {
        internal HelloStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var logGroup = new LogGroup(this, "Levi-LogGroup", new LogGroupProps
            {
                LogGroupName = "Levi-Test",
                Retention = RetentionDays.ONE_MONTH,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
        }
    }
}
