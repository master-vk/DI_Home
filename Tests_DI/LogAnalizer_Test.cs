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


        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
