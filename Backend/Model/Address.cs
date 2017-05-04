using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Model
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Street}, {City}, {Country}";
        }
    }
}
