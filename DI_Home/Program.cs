using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DI_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            //var typeName = ConfigurationManager.AppSettings["messageWriter"];
            //var type = Type.GetType(typeName, true);

            //IMessager writer =  (IMessager)Activator.CreateInstance(type);

            IMessager writer = new SecureMessageWriter(new ConsoleMessager());

            var salutation = new Salutation(writer);
            salutation.Exclaim();

            Console.ReadKey();
        }
    }
}
