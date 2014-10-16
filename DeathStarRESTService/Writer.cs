using System;
using System.Configuration;
using System.IO;
using ITCR.Domain.Entities;

namespace DeathStarRESTService
{
    /// <summary>
    /// Singleton object that will allow writing skywalker attemps to a file
    /// The path and filename should be declared in AppSettings at app.config or web.config
    /// </summary>
    public class Writer : IDisposable
    {

        private static Writer _instance;
        public static Writer Current { get { return _instance ?? (_instance = new Writer()); } }

        private string _filename;
        public string FileName
        {
            get { return _filename; }
        }

        public void Write(SkywalkerAlert alert)
        {
            var output =  String.Format("{0:G} | {1} | {2} | {3} | {4} | {5}",
                alert.Timestamp,
                alert.Name,
                (alert.Specie ?? new Specie()).Description,
                (alert.Role ?? new Role()).Description,
                alert.ClientIP,
                alert.BrowserInfo);

            using (StreamWriter w = File.AppendText(FileName))
                w.WriteLine(output);
        }

        public Writer()
        {
            _filename = ConfigurationManager.AppSettings["LogFileName"];
            // if the appsetting is not present, use a default "alerts.txt" at the app folder
            if (string.IsNullOrEmpty(_filename)) _filename = "alerts.txt";
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}