using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() => {
            var fixture = new Fixture();
            fixture.Customizations.Add(new EFCoreModelBuilder());
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true, GenerateDelegates = true });

            return fixture;
        })
        { }
    }
}
