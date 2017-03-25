using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public interface IEmailService
    {
        void SendEmail(EmailInfo email);
    }
}
