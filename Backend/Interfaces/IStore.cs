using Klarna.YPSearch.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Interfaces
{
    public interface IStore
    {
        List<Person> Search(string query);
        List<Person> Get(int size);
    }
}
