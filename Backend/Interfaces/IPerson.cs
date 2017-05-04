﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Interfaces
{
    public interface IPerson
    {
        string Id { get;  }
        string Name { get; set; }
        int Age { get; set; }
        string Address { get; set; }
        string ImageUrl { get; set; }
        string Phone { get; set; }

    }
}
