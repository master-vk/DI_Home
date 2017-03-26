using DI_Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI
{
    public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public bool IsSupported;

        public IExtensionManager manager;
        protected override IExtensionManager GetManager()
        {
            return manager;
        }
        protected override bool IsValid(string fileName)
        {
            return IsSupported;
        }
    }
}
