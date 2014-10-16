using System;

namespace ITCR.Domain.Exceptions
{
    /// <summary>
    /// Handles all the application's exceptions
    /// </summary>
    public class BaseException : Exception
    {
        public bool Handled { get; set; }
        public BaseException(string message) : base(message) { }
        public BaseException(Exception ex) : this(ex.Message, ex) { }
        public BaseException(string message, Exception ex) : base(message, ex) { }

        public static void HandleException(Exception ex, bool reRaise = true)
        {
            // Try to convert the exception to our type if it isn't already
            var bEx = (ex as BaseException) ?? new BaseException(ex);
            // If it hasn't been logged, do it now...
            if (!bEx.Handled)
            {
                Logger.Log(ex);
                bEx.Handled = true;
            }
            // ReRaise the exceptiojn to the next layer (it won't be logged again)
            if (reRaise) throw bEx;
        }
    }
}
