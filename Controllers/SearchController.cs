using System;
using Microsoft.AspNetCore.Mvc;
using Klarna.YPSearch.Repository;
using Klarna.YPSearch.Core.Interfaces;
using Klarna.YPSearch.Core.Model;
using System.Linq;

namespace ngYPSearch.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private const int MaxFetch = 25;
        // there is 1 instance of the Store
        private static YellowPagesStore _store = new YellowPagesStore();
        private static ILogger logger = new Klarna.YPSearch.Core.Logger.SimpleLogger();

                

        [HttpGet("[action]/{term}")]
        public IActionResult TermSearch(string term)
        {
            try
            {
                return new ObjectResult(_store.Search(term).Take(MaxFetch).ToArray());
            }
            catch (Exception e)
            {
                logger.Error(e, $"Could not perform Search Query : {term} ");
            }

            return new ObjectResult(new Person[0]); 
        }

        [HttpGet("[action]")]
        public IActionResult GetPeople()
        {
            try
            {
                return new ObjectResult(_store.Get(100));
            }
            catch (Exception e)
            {
                logger.Error(e, $"Could not perform GetPeople");
            }

            return new ObjectResult(new Person[0]);
        }

    }
}
