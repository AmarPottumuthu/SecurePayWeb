using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePayWeb.CustomException
{
    public class NoSuitableDriver : Exception
    {
        public NoSuitableDriver(string msg, string v) : base(msg)
        {

        }
    }
}
