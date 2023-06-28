using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PersonService : IPersionService
    {
        public Person Create(string name, int age)
        {
            return new Person() { Name = name, Age = age };
        }

        public string GetName(Person person)
        {
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
