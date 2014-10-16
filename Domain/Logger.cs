using System;
using System.Diagnostics;

namespace ITCR.Domain
{
    /// <summary>
    ///  Singleton Pattern: Logs exceptions
    /// </summary>
    public class Logger : IDisposable
    {

        public static Logger _log;
        public static Logger Current { get { return _log ?? (_log = new Logger());  } }

        public static void Log(string msg) { }

        public static void Log(Exception ex)
        {
            // TODO: IMPLEMENT ANY LOGGING LIBRARY
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }

        public void Dispose()
        {
            _log = null;
        }
    }
}
