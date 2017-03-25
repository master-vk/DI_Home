using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public class LogAnalyzer2
    {
        private IWebService _service;
        private ILogger _loger;
        public LogAnalyzer2(ILogger loger, IWebService service)
        {
            _loger = loger;
            _service = service;
        }

        public int MinNameLength { get; set; }
        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _loger.LogError("Too short file name" + fileName);
                }
                catch (Exception e)
                {
                    _service.Write("Registrator's error: " + e);
                }
            }
        }
    }
}
