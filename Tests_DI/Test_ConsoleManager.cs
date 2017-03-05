using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Remoting.Messaging;
using DI_Home;
using Moq;

namespace Tests_DI
{
    [TestClass]
    public class Test_ConsoleManager
    {
        [TestMethod]
        public void Test_Write()
        {
            var writer = new Mock<IMessager>();
            var sut = new Salutation(writer.Object);

            sut.Exclaim();
            writer.Verify(w => w.Write("Hello DI"));
        }
    }
}
