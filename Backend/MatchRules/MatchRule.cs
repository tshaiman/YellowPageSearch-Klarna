using System;
using System.Collections.Generic;
using System.Linq;
using Klarna.YPSearch.Core;
using Klarna.YPSearch.Core.Model;
using Klarna.YPSearch.Core.Utils;

namespace Klarna.YPSearch.Repository.Match
{
    public class MatchRule
    {
        //we might have more than 1 name token
        public List<string> nameTokens { get; set; }
        //we might have more then 1 items a an Age Candidate test (e.g "50 Cent 60")
        public List<int> ageTokens { get; set; }
        //The phone token may be null 
        public string phone { get; set; }

        public MatchRule()
        {
            nameTokens = new List<string>();
            ageTokens = new List<int>();
        }

        

        public bool IsMatch(Person p)
        {
            //if we have a name in the rule -> try to match it
            if (!string.IsNullOrEmpty(phone) && !p.Phone.Equals(phone))
                return false;

            //if there are no names and ages to mathc -> we're done.
            if (!nameTokens.Any()  && !ageTokens.Any()) return true;

            //For names and ageTokens we try several combinations
            return MathcNameAgeCombinatsion(p,nameTokens.ToList(),ageTokens.ToList());
        }

        
        private bool MathcNameAgeCombinatsion(Person p,List<string> names,List<int> ages)
        {
            if (!ages.Any())
                return MatchOnlyNames(p, names);
            
            //add all "non-age" values to the name
            var nonAges = ages.Where(x => x != p.Age).Select(x=>x.ToString()).ToList();
            var found = ages.Where(x => x == p.Age).Select(x => x.ToString()).ToList();
            
            var modified = names.ToList();
            modified.AddRange(nonAges);

            if (found.Count > 1)
            {
                //add count-1 items to the name tokens
                for(int i=0; i < found.Count -1 ; ++i)
                    modified.Add(found[0]);
            }
            return MatchOnlyNames(p, modified);
       }

        
        private bool MatchOnlyNames(Person p, List<string> names)
        {
            foreach (var name in names)
            {
                if (!p.Name.CaseInsensitiveContains(name))
                    return false;
            }
            return true;
        }

        

        
        
    }
}
