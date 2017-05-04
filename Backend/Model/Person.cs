using Klarna.YPSearch.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Core.Model
{
    public class Person : IPerson
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; } // a blob storage image
        

        public Person()
        {

        }
       
        public Person(string id,string name, int age,string phone = null,string address = null ,string imageUrl=null)
        {
            Id = id;
            Phone = phone;
            Name = name;
            Age = age;
            Address = address;
            ImageUrl = imageUrl;
        }
    }

    
}
