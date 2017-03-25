using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DI_Home;

namespace Tests_DI
{
    [TestFixture]
    public class LogAnalizer_Test
    {
        [Test]
        [TestCase("hello.SLF")]
        public void IsValidFileName_BadExtension_ReturnsFalse(string fileName)
        {
            var logAnalyzer = new LogAnalyzer();

            var result = logAnalyzer.IsValidFileName(fileName);

            Assert.AreEqual(false, result);
        }

        [Test]
        [TestCase("")]
        [Category("Fast")]
        public void IsValidFileName_ExpectedException(string fileName)
        {
            var logAnalyzer = MakeAnalyzer();
            var ex = Assert.Catch<ArgumentNullException>(() => logAnalyzer.IsValidFileName(fileName));
        }

        [Test]
        public void IsValidCreate_ExpectedObject(string fileName)
        {
            Assert.IsNull(ExtensionManagerFactory.customManager);
            Assert.IsInstanceOf(new FileExtensionManager().GetType(), ExtensionManagerFactory.Create());
        }
        [Test]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidFileName("badname.foo");
            Assert.False(la.WasLastFileNameValid);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.SVF", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidFileName(file);
            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }
        [TestFixture]
        public class LogAnalyzerTests
        {
            [Test]
            public void
            IsValidFileName_NameSupportedExtension_ReturnsTrue()
            {
                FakeExtensionManager myFakeManager = new FakeExtensionManager();
                myFakeManager.WillBeValid = true;
                LogAnalyzer log = new LogAnalyzer();
                log.ExtensionManager = myFakeManager;
                bool result = log.IsValidFileName("short.ext");
                Assert.True(result);
            }
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            LogAnalyzer log = MakeAnalyzer();

            myFakeManager.WillThrow = new Exception("");            
            log.ExtensionManager = myFakeManager;

            bool result = log.IsValidFileName("anything.anyextension");
            Assert.False(result);
        }
        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            LogAnalyzer log = MakeAnalyzer();

            myFakeManager.WillThrow = new Exception("");
            log.ExtensionManager = myFakeManager;

            bool result = log.IsValidFileName("anything.anyextension");
            Assert.True(result);
        }
        [Test]
        public void overrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;
            TestableLogAnalyzer logan = new TestableLogAnalyzer();
            bool result = logan.IsValidLogFileName("lfjile.ext");
            Assert.True(result);
        }

        [Test]
        public void overrideTestWithoutStub()
        {
            TestableLogAnalyzer logan = new TestableLogAnalyzer();
            logan.IsSupported = true;
            bool result = logan.IsValidLogFileName("file.ext");
            Assert.True(result,"...");
        }
        
        [Test]
        [Ignore("not actual")]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockService);
            string tooShortFileName ="abc.ext";

            log.Analyze(tooShortFileName);

            //StringAssert.Contains("Too short name: abc.ext", mockService.LastError);
        }
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            FakeLogger logger = new FakeLogger();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            StringAssert.Contains("Too short name", logger.LastError);
        }
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
