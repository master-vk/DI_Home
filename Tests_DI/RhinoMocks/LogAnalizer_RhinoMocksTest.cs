using DI_Home;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.Mocks;

namespace Tests_DI.RhinoMocks
{
    [TestFixture]
    class LogAnalizer_RhinoMocksTest
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = MockRepository.GenerateMock<ILogger>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            logger.AssertWasCalled(x => x.LogError("Too short name: a.txt"));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSub()
        {
            var mockWebService = MockRepository.GenerateMock<IWebService>();
            var stubLogger = MockRepository.GenerateStub<ILogger>();

            stubLogger.Stub(x => x.LogError("Too short name: a.txt"))
                      .IgnoreArguments()
                      .Throw(new Exception("fake exception"));

            var analyzer = new LogAnalyzer2(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.AssertWasCalled(x => x.Write(Arg.Text.Contains("fake exception")));
        }
    }
}
