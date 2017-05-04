using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Klarna.YPSearch.Core.Interfaces;
using Klarna.YPSearch.Core.Model;
using Klarna.YPSearch.Repository;
using Newtonsoft.Json;
using Klarna.YPSearch.Core.Logger;
using Klarna.YPSearch.Repository.Match;

namespace Klarna.YPSearch.Repository
{
    /* The store "mimics" the use of a read DB repository , of course in real production
    we can't simply load all the data into memory.
    this layer will be a NoSql table (elastic/ Mongo) in real life system
    */
    public class YellowPagesStore : IStore
    {
        #region Constants 
        private static string _path;
        private static ILogger _logger = new SimpleLogger();
        #endregion
        #region Initialization and Startup
        private Lazy<Searcher> LazySearcher = new Lazy<Searcher>(()=>new Searcher());
        private Lazy<List<Person>> Lazystore = new Lazy<List<Person>>(InitStore);

        private Searcher _searcher => LazySearcher.Value;
        private List<Person> _store => Lazystore.Value;
        

        private static List<Person> InitStore()
        {
            //Read from File location
            ///TODO  : Place in Config
            _path = @".\App_Data\people.json";
            
            
            try
            {
                var allLines = System.IO.File.ReadAllLines(_path);
                var first = allLines.First();
                return allLines.Select(l => (JsonConvert.DeserializeObject<PersonDbModel>(l))?.ToPerson()).ToList();
            }
            catch(Exception e)
            {
                _logger.Error(e, "Could not initialize Person Datastore");
            }
            return new List<Person>();
        }
        #endregion
        #region IStore API
        /// <summary>
        /// The Search API
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Person> Search(string query)
        {
            return _searcher.Search(_store, query);
        }

        /// <summary>
        /// Get size Persons
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<Person> Get(int size)
        {
            return _store.Take(size).ToList();
        }

        //TODO : more CRUD operations here....... (Insert/Update / Delete)

        #endregion
    }
}
