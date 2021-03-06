﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Home
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;
        private IWebService service;
        private ILogger logger;
        public int MinNameLength { get; set; }
        public bool WasLastFileNameValid { get; set; }
        public IExtensionManager ExtensionManager
        {
            get { return manager; }
            set { manager = value; }
        }

        public LogAnalyzer(ILogger logger)
        {
            this.logger = logger;
        }
        public LogAnalyzer(IWebService service)
        {
            this.service = service;
        }
        public LogAnalyzer()
        {
            this.manager = ExtensionManagerFactory.Create();
        }
        public void Analyze(string fileName)
        {

            if (fileName.Length < MinNameLength)
            {
                logger.LogError("Too short name: " + fileName);
            }

        }

        public bool IsValidFileName(string fileName)
        {
            IExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName) && Path.GetFileNameWithoutExtension(fileName).Length > 5;
        }
    }
}
