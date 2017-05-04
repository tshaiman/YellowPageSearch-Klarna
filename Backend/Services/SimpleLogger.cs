using Klarna.YPSearch.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Logger
{
    // Could be extended to be Splunk/Loggly/File logger etc.
    public class SimpleLogger : ILogger
    {
        
        public void Info(string message)
        {
            Write("Info",null, message);
        }

        public void Error(Exception e, string message)
        {
            Write("Warn", e, message);
        }

        public void Warn(Exception e, string message)
        {
            Write("Warn", e, message);
        }

        private void Write(string level,Exception ex, string message)
        {
            string msg;
            if(ex != null)
                msg = $"{level.ToUpper()} - [{DateTime.UtcNow.ToString()}] - Exception : {ex.Message} , Message : {message}";
            else
                msg = $"{level.ToUpper()} - [{DateTime.UtcNow.ToString()}] - Message : {message}";
            Console.WriteLine(msg);
        }
    }
}
