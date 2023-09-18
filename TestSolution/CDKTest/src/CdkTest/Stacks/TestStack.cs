
using Amazon.CDK;
using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.Logs;
using CDK.EC2.KeyPair;
using CdkTest.NestedStacks;
using Constructs;

namespace CdkTest.Stacks
{
    public class TestStack : Stack
    {
        internal TestStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var suffix = 0;
            var keyPair = new KeyPair(this, $"KeyPair{suffix}", new KeyPairProps
            {
                Name = $"levi-test",
                ExposePublicKey = true,
                StorePublicKey = true,
                PublicKeyFormat = PublicKeyFormat.PEM,
                ResourcePrefix = Node.Id,
                SecretPrefix = "Keys/"
            });

            var publicKey = new PublicKey(this, $"PublicKey{suffix}", new PublicKeyProps
            {
                EncodedKey = keyPair.PublicKeyValue
            });

        }
    }
}
