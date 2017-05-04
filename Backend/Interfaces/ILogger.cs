using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(Exception e, string message);
        void Error(Exception e, string message);
    }
}
