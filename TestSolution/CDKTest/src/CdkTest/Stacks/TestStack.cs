
using Amazon.CDK;
using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.Events.Targets;
using Amazon.CDK.AWS.Events;
using Amazon.CDK.AWS.Logs;
using CDK.EC2.KeyPair;
using CdkTest.NestedStacks;
using Constructs;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.StepFunctions.Tasks;
using Amazon.CDK.AWS.Config;
using Amazon.CDK.AWS.ECS;

namespace CdkTest.Stacks
{
    public class TestStack : Stack
    {
        internal TestStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            //var suffix = 0;
            //var keyPair = new KeyPair(this, $"KeyPair{suffix}", new KeyPairProps
            //{
            //    Name = $"levi-test",
            //    ExposePublicKey = true,
            //    StorePublicKey = true,
            //    PublicKeyFormat = PublicKeyFormat.PEM,
            //    ResourcePrefix = Node.Id,
            //    SecretPrefix = "Keys/"
            //});

            //var publicKey = new PublicKey(this, $"PublicKey{suffix}", new PublicKeyProps
            //{
            //    EncodedKey = keyPair.PublicKeyValue
            //});

            var topic = new Topic(this, "levi-test-topic");
            topic.AddSubscription(new EmailSubscription("levi.zhou@securitas.com"));

            var rule = new ManagedRule(this, "levi-test-S3BucketLevelPublicAccessProhibited", new ManagedRuleProps
            {
                Identifier = ManagedRuleIdentifiers.S3_BUCKET_LEVEL_PUBLIC_ACCESS_PROHIBITED,
                ConfigRuleName = "levi-test-S3BucketLevelPublicAccessProhibitedRule",
                //MaximumExecutionFrequency = MaximumExecutionFrequency.TWENTY_FOUR_HOURS, // A maximum execution frequency for this rule is not allowed because only a change in resources triggers this managed rule.
                RuleScope = RuleScope.FromResources(new[] { ResourceType.S3_BUCKET })
            });

            rule.OnComplianceChange("TopicEvent", new OnEventOptions
            {
                Target = new SnsTopic(topic)
            });
        }
    }
}
