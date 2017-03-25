using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI_Home;

namespace Tests_DI
{
    public class FakeLogger : DI_Home.ILogger
    {
        public string LastError { get; set; }
        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
