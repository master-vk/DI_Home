using DI_Home;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI.Subtitute
{
    public class LogAnalizer_Test
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            analyzer.Analyze("a.txt");

            logger.Received().LogError("Too short name: a.txt");
        }
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("file.name").Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("file.name"));
        }

        [Test]
        public void Returns_ArgAny_IgnoresArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("anything, really"));
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(x => { throw new Exception("fake exception"); });


            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));

        }
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSub()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                      .Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzer2(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.Received()
                          .Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}
