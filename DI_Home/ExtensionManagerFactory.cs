using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public static class ExtensionManagerFactory
    {
        public static IExtensionManager customManager = null;
        public static IExtensionManager Create()
        {
            if (customManager != null)
                return customManager;
            return new FileExtensionManager();
        }
        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
