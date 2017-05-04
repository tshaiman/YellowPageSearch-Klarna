using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Utils
{
    public static class Extensions
    {
        private static DateTime epoc = new DateTime(1970, 1, 1);
        private static DateTime zeroTime = new DateTime(1, 1, 1);

        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static DateTime GetDate(this long epocTime)
        {
            return epoc.AddSeconds(epocTime);
        }

        public static int Age(this long epocTime)
        {
            try
            {
                var diff = (DateTime.UtcNow - epocTime.GetDate());
                return (zeroTime + diff).Year - 1;
            }
            catch(Exception e)
            {
            }
            return 0;
            
        }
    }
}
