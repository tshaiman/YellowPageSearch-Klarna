using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Klarna.YPSearch.Repository.Match
{
    public abstract class TokenMatcher
    {
        internal abstract void Parse(MatchRule rule, List<string> tokens);
    }

    public class PhoneTokenMatcher : TokenMatcher
    {
        private string pattern = @"^[0-9]\d{3}-\d{5,6}$";
        internal override void Parse(MatchRule rule, List<string> tokens)
        {
            string founded = null;
            Regex regEx = new Regex(pattern);
            foreach (var token in tokens)
            {
                if (regEx.IsMatch(token))
                {
                    founded = token;
                    break;
                }
            }
            if (founded == null) return;
            //remove the token from future processing
            tokens.Remove(founded);
            rule.phone = founded;
        }
    }

    public class AgeTokenMatcher : TokenMatcher
    {
        private const int MinAge = 0; // TODO : Configuration
        private const int MaxAge = 120; // TODO : Configuration

        internal override void Parse(MatchRule rule, List<string> tokens)
        {
            int age = 0;
            List<string> founded = new List<string>();
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out age) && age >=MinAge && age<=MaxAge)
                {
                    founded.Add(token);
                    rule.ageTokens.Add(age);
                }
            }
            
            //remove the founded from future processing
            tokens.RemoveAll(x => founded.Contains(x));

        }
    }


    public class NameTokenMatcher : TokenMatcher
    {
        internal override void Parse(MatchRule rule, List<string> tokens)
        {
            //Simply Add all tokens to the name part
            foreach(var n in tokens)
            {
                rule.nameTokens.Add(n);
            }
        }
    }
}
