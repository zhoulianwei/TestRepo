using AutoFixture;
using AutoFixture.NUnit3;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using static UnitTest.PersonServiceTest;

namespace UnitTest
{
    [TestFixture]
    public class PersonServiceTest
    {
        private IPersionService PersionService { get; }

        public PersonServiceTest()
        {
            PersionService = new PersonService();
            Console.WriteLine("Begin Constructor");
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Begin Setup");
        }

        [Test]
        public void Create_WithPersionInfo_ReturnPersion()
        {
            var zhangsan = PersionService.Create("zhangsan", 18);
            Assert.IsTrue(zhangsan.Name == "zhangsan");
            Assert.IsTrue(zhangsan.Age == 18);
        }

        [Test]
        public void Test()
        {
            var mockPersonService = new Mock<IPersionService>();
            var person1 = mockPersonService.Object.GetName(null); // zhangsan
            mockPersonService.Verify(p => p.GetName(null), Times.Once);
            Assert.Pass();
        }
    }


}