using DI_Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI
{
    public class FakeWebService : IWebService
    {
        public Exception ToThrow;
        public void Write(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}
