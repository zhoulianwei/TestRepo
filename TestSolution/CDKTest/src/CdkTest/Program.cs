﻿using Amazon.CDK;
using CdkTest.Aspects;
using CdkTest.Stacks;
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


            _ = new TestStack(app, "Levi-TestStack", stackProp);


            app.Synth();
        }
    }
}
