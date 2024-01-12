
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
using Amazon.CDK.AWS.AutoScaling;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.RDS;
using Amazon.CDK.AWS.CloudWatch;
using Amazon.CDK.AWS.SES.Actions;
using System.Collections.Generic;
using Amazon.CDK.AWS.ElasticLoadBalancingV2;
using Amazon.CDK.AWS.IAM;
using System.IO;
using System;
using Amazon.CDK.AWS.GlobalAccelerator;

namespace CdkTest.Stacks
{
    public class TestStack : Stack
    {
        internal TestStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var keyPair = new KeyPair(this, $"levitest0", new KeyPairProps
            {
                Name = "levikeypair0",
                ExposePublicKey = true,
                StorePublicKey = true,
                PublicKeyFormat = PublicKeyFormat.PEM,
                ResourcePrefix = Node.Id,
                SecretPrefix = "Keys/"
            });

            var publicKey = new PublicKey(this, $"cfPublicKeylevitest0", new PublicKeyProps
            {
                EncodedKey = keyPair.PublicKeyValue
            });


            // 将LoadBalancer添加到自动扩展组
            //autoScalingGroup.AttachToApplicationTargetGroup(targetGroup);

            //// 创建CfnEnvironment
            //var cfnEnvironment = new Amazon.CDK.AWS.ElasticBeanstalk.CfnEnvironment(this, "CfnEnvironment", new Amazon.CDK.AWS.ElasticBeanstalk.CfnEnvironmentProps
            //{
            //    EnvironmentName = "MyEnvironment",
            //    ApplicationName = "MyApplication",
            //    PlatformArn = "arn:aws:elasticbeanstalk:us-west-2::platform/ExamplePlatform/1.0.0",
            //    OptionSettings = new[]
            //    {
            //        new Amazon.CDK.AWS.ElasticBeanstalk.CfnEnvironment.OptionSettingProperty
            //        {
            //            Namespace = "aws:elasticbeanstalk:environment",
            //            OptionName = "MyOption",
            //            Value = "MyValue"
            //        }
            //    }                
            //});

            //// 将LoadBalancer与CfnEnvironment关联
            //cfnEnvironment.Node.AddDependency(loadBalancer);


            //var cpuUtilizationMetric = new Metric(new MetricProps
            //{
            //    Namespace = "AWS/EC2",
            //    MetricName = "CPUUtilization",
            //    Statistic = "Average",
            //    Period = Duration.Minutes(5),
            //    DimensionsMap = new Dictionary<string, string>
            //         {
            //            { "AutoScalingGroupName", "awseb-e-j3jwmk2avx-stack-AWSEBAutoScalingGroup-ET04BCQJ7R5K" } // TODO
            //        },
            //});

            //var requestCountMetric = new Metric(new MetricProps
            //{
            //    Namespace = "AWS/ApplicationELB",
            //    MetricName = "RequestCount",
            //    Statistic = "Sum",
            //    Period = Duration.Minutes(5),
            //    DimensionsMap = new Dictionary<string, string>
            //         {
            //            { "LoadBalancer", "app/awseb-AWSEB-1TF3A844QI2W3/4dd4278b3355fdc2" } // TODO
            //        },
            //});

            //var ebsScaleInExpression = new Amazon.CDK.AWS.CloudWatch.MathExpression(new MathExpressionProps
            //{
            //    Label = "ElasticBeanstalkScaleInExpression",
            //    Expression = "IF( cpuUtilization < 20 AND requestCount < 2000, 1, 0)",
            //    UsingMetrics = new Dictionary<string, IMetric>()
            //        {
            //            { "cpuUtilization", cpuUtilizationMetric },
            //            { "requestCount", requestCountMetric }
            //        },
            //});

            //ebsScaleInExpression.CreateAlarm(this, "ElasticBeanstalkScaleInAlarm", new AlarmProps
            //{
            //    AlarmName = "ElasticBeanstalk Scale In Alarm",
            //    AlarmDescription = "This Alarm is used by the Auto Scaling Group as a condition for automatic scaling in.",
            //    Threshold = 1,
            //    ComparisonOperator = ComparisonOperator.GREATER_THAN_OR_EQUAL_TO_THRESHOLD,
            //    EvaluationPeriods = 1,
            //    DatapointsToAlarm = 1,
            //    TreatMissingData = TreatMissingData.NOT_BREACHING
            //});


            //var vpc = new Vpc(this, "levi-vpc", new VpcProps
            //{
            //    Cidr = "10.0.0.0/16",
            //    MaxAzs = 2,
            //    SubnetConfiguration = new ISubnetConfiguration[]
            //    {
            //        new SubnetConfiguration
            //        {
            //            CidrMask = 24,
            //            SubnetType = SubnetType.PUBLIC,
            //            Name = "levi-PublicSubnet"
            //        },
            //        new SubnetConfiguration
            //        {
            //            CidrMask = 24,
            //            SubnetType = SubnetType.PRIVATE_WITH_EGRESS,
            //            Name = "levi-PrivateSubnet"
            //        }
            //    }
            //});

            //var instance = new DatabaseInstance(this, "levi-test-db",
            //    new DatabaseInstanceProps
            //    {
            //        DatabaseName = "levitestdb",
            //        Port = 5432,
            //        Vpc = vpc,
            //        VpcSubnets = new SubnetSelection { SubnetType = SubnetType.PUBLIC },

            //        InstanceType = new Amazon.CDK.AWS.EC2.InstanceType("t4g.micro"),
            //        Engine = DatabaseInstanceEngine.Postgres(new PostgresInstanceEngineProps { Version = PostgresEngineVersion.VER_15_4 }),
            //    });





            //// 创建 Auto Scaling Group
            //var autoScalingGroup = new AutoScalingGroup(this, "LeviAutoScalingGroup", new AutoScalingGroupProps
            //{

            //});


            //// 基于传入字节数设置自动伸缩配置
            //autoScalingGroup.ScaleOnIncomingBytes("NetworkInScaling", new NetworkUtilizationScalingProps
            //{
            //    TargetBytesPerSecond = 100000,
            //});


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

            //var topic = new Topic(this, "levi-test-topic");
            //topic.AddSubscription(new EmailSubscription("levi.zhou@securitas.com"));

            //var rule = new ManagedRule(this, "levi-test-S3BucketLevelPublicAccessProhibited", new ManagedRuleProps
            //{
            //    Identifier = ManagedRuleIdentifiers.S3_BUCKET_LEVEL_PUBLIC_ACCESS_PROHIBITED,
            //    ConfigRuleName = "levi-test-S3BucketLevelPublicAccessProhibitedRule",
            //    //MaximumExecutionFrequency = MaximumExecutionFrequency.TWENTY_FOUR_HOURS, // A maximum execution frequency for this rule is not allowed because only a change in resources triggers this managed rule.
            //    RuleScope = RuleScope.FromResources(new[] { ResourceType.S3_BUCKET })
            //});

            //rule.OnComplianceChange("TopicEvent", new OnEventOptions
            //{
            //    Target = new SnsTopic(topic)
            //});





        }
    }
}
