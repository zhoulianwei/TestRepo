using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public interface IPersonService
    {
        public Person Create(string name, int age);
        public string GetName(Person person);
        public int GetAge(Person person);
        public bool IsZhangsan(Person person);
    }
}
