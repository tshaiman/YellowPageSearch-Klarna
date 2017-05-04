using Klarna.YPSearch.Core.Model;
using Klarna.YPSearch.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Repository
{
    /**
     * representation of the Person object as it presented in the storage layer (full json fields)
     */
    public class PersonDbModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatar_image { get; set; }
        public string avatar_origin { get; set; }
        public long birthday { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }

        //PersonDb To Person Mapper
        public Person ToPerson()
        {
            return new Person(this.id,this.name, birthday.Age(),this.phone,this.address.ToString(),this.getImageUrl());
        }

       
        private string getImageUrl()
        {
           /* if (!string.IsNullOrEmpty(avatar_image))
                return avatar_image;*/
            return avatar_origin;
        }
    }


    
}
