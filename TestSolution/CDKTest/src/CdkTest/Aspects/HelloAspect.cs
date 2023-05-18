using Amazon.CDK;
using Amazon.CDK.AWS.Logs;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdkTest.Aspects
{
    internal class HelloAspect : DeputyBase, IAspect
    {
        public void Visit(IConstruct node)
        {
            Console.WriteLine($"Find a resource : {node}");
            if (node is CfnLogGroup logGroup)
            {
                Console.WriteLine($"Find a log group : {logGroup.LogGroupName}");
            }
        }
    }
}
