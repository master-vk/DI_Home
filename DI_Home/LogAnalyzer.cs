using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException();
            }
            if (!fileName.Contains(".SVF"))
            {
                return false;
            }       

            WasLastFileNameValid = true;
            return true;
        }
    }
}
