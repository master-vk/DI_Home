using DI_Home;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();
            LogAnalyzer22 log = new LogAnalyzer22(mockEmail, stubService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            StringAssert.Contains("someone@somewhere.com", mockEmail.email.To);
            StringAssert.Contains("fake exception", mockEmail.email.Body);
            StringAssert.Contains("can't log", mockEmail.email.Subject);

        }
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail2()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();
            LogAnalyzer22 log = new LogAnalyzer22(mockEmail, stubService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);
            EmailInfo expectedEmail = new EmailInfo
            {
                Body = "fake exception",
                To = "someone@somewhere.com",
                Subject = "can't log"
            };
            Assert.AreEqual(expectedEmail, mockEmail.email);
        }

    }
}
