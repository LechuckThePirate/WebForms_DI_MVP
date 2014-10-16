using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using DeathStarService.Models;

namespace DeathStarService
{
    public class Writer
    {

        public static Writer Current { get; set; }

        private string _filename;
        public string FileName
        {
            get { return _filename; }
        }

        public void Write(SkywalkerAlert alert)
        {
            using (StreamWriter w = File.AppendText(FileName))
                w.WriteLine(alert.ToString());
        }

        public Writer()
        {
            Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
            _filename = cfg.AppSettings.Settings["LogFileName"].Value;
        }

    }
}