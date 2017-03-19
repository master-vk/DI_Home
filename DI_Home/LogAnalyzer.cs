using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public class LogAnalyzer
    {
        IExtensionManager manager;
        public bool WasLastFileNameValid { get; set; }
        public IExtensionManager ExtensionManager
        {
            get { return manager; }
            set { manager = value; }
        }

        public LogAnalyzer()
        {
            this.manager = new FileExtensionManager();
        }
        public bool IsValidFileName(string fileName)
        {
            IExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName);
        }
    }
}
