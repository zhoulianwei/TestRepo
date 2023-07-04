using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public interface ICommonService
    {
        String Flag { get; }

        public void WriteInfo();
    }
}
