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
    public class NSubBasics_Test
    {
        [Test]
        public void SubstituteFor_ForInterfaces_ReturnsAFakeInterface()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            Assert.IsFalse(fakeRules.IsValidLogFileName("something.bla"));
        }
    }
}
