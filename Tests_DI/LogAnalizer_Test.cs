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

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
