using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class CommonService : ICommonService
    {
        public string Flag { get; set; } = "A";

        public void WriteInfo()
        {
            Console.WriteLine(Flag);
        }
    }
}
