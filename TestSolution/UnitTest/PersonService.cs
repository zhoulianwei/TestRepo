using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PersonService : IPersonService
    {

        public ICommonService CommonService { get; set; }


        public Person Create(string name, int age)
        {
            return new Person() { Name = name, Age = age };
        }

        public string GetName(Person person)
        {
            CommonService.WriteInfo();
            return person.Name;
        }

        public int GetAge(Person person)
        {
            return person.Age;
        }

        public bool IsZhangsan(Person person)
        {
            return person.Name.ToLower() == "zhangsan";
        }
    }
}
