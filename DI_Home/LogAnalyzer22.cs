using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public class LogAnalyzer22
    {
        public LogAnalyzer22(IEmailService email, IWebService service)
        {
            Email = email;
            Service = service;
        }
        public IWebService Service
        {
            get;
            set;
        }
        public IEmailService Email
        {
            get;
            set;
        }
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.Write("Too short file name" + fileName);
                }
                catch (Exception e)
                {
                    Email.SendEmail(new EmailInfo { To = "someone@somewhere.com", Subject = "can't log", Body = e.Message });
                }
            }
        }
    }
}
