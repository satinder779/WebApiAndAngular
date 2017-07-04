using System;
using System.Configuration;

namespace iassetTechnicalTest.Web
{
    public class Settings
    {
        private static Settings _instance;

        private Settings()
        {
        }

        public static Settings Instance
        {
            get { return _instance ?? (_instance = new Settings()); }
        }

        public string GWServiceAddress
        {
            get { return ConfigurationManager.AppSettings["GWServiceAddress"]; }
        }
    }
}