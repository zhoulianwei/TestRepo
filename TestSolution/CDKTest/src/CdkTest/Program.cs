using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CdkTest
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();

            var enviroment = new Amazon.CDK.Environment
            {
                Account = "465671368404",
                Region = "us-east-2",
            };
            var stackProp = new StackProps { Env = enviroment };

            new LeviTestStack(app, "LeviTestStack", stackProp);

            app.Synth();
        }
    }
}
