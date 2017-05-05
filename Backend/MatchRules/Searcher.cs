using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klarna.YPSearch.Core.Model;

namespace Klarna.YPSearch.Repository.Match
{
    //Search implements the Token Matcher by itself in a "Composite" design Pattern
    public class Searcher : TokenMatcher
    {
        private static TokenMatcher[] tokenMatchers;
        private static MatchRule _matchRule; // The current Match Rule !

        //Same Tokens For all Cases ,hence the Static
        static Searcher()
        {
            tokenMatchers = new TokenMatcher[3];
            tokenMatchers[0] = new PhoneTokenMatcher();
            tokenMatchers[1] = new AgeTokenMatcher();
            tokenMatchers[2] = new NameTokenMatcher();
        }

        
        internal List<Person> Search(List<Person> persons,string phrase)
        {
            var matchRule = CreateRule(phrase);
            var result = persons.Where(p => matchRule.IsMatch(p)).ToList();

            //TODO : Use Rank mechnaims to detect which has the better match and return results accordingly
            try{persons.Sort(new PersonComparer());}catch(Exception e){ }

            return result;

        }

        
        private MatchRule CreateRule(string phrase)
        {
            //Build an Parse the match Rules
            var phraseTokens = phrase.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
            var rule = new MatchRule();
            Parse(rule, phraseTokens);
            return rule;
        }


        internal override void Parse(MatchRule rule,List<string> tokens)
        {
            foreach (var token in tokenMatchers)
            {
                token.Parse(rule, tokens);
            }

        }

        
    }
}
