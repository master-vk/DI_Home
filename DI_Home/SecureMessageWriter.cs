using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DI_Home
{
    internal class SecureMessageWriter : IMessager
    {
        private readonly IMessager writer;
        public SecureMessageWriter(IMessager writer)
        {
            if (writer == null)
            {
                throw new NotImplementedException();
            }
            this.writer = writer;
        }
        public void Write(string message)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                this.writer.Write(message);
            }
        }
    }
}
