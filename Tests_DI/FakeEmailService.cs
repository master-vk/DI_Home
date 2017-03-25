using DI_Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI
{
    public class FakeEmailService : IEmailService
    {
        public EmailInfo email = null;
        public void SendEmail(EmailInfo emailInfo)
        {
            email = emailInfo;
        }
    }
}
