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
        private IPersonService PersionService { get; }

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

        [Test, AutoMoqData]
        public void Test(Mock<Person> mockPerson,
            //Mock<ICommonService> mockCommonService, 
            PersonService sut)
        {
            //mockCommonService.Setup(m => m.WriteInfo());

            var person1 = sut.GetName(mockPerson.Object);

            Assert.Pass();
        }
    }


}