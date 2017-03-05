using System;

namespace DI_Home
{
    public class Salutation
    {
        private IMessager writer;

        public Salutation(IMessager writer)
        {
            if(writer == null)
            {
                throw new NotImplementedException();
            }
            this.writer = writer;
        }

        public void Exclaim()
        {
            this.writer.Write("Hello DI");
        }
    }
}