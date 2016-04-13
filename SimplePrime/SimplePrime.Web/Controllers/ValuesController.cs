using PrimeActor.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimplePrime.Web.Controllers
{
    public class PrimeIndexes
    {
        public int  From { get; set; }
        public int To { get; set; }
    }

    public class ValuesController : ApiController
    {
        private readonly int DEFAULT_FROM = 1;
        private readonly int DEFAULT_TO = 100;

        // GET api/values 
        public Task<List<int>> Get()
        {
            //List<int> listResult = new List<int>();
            //listResult.Add(DEFAULT_FROM);
            //listResult.Add(DEFAULT_TO);
           IPrimeActor actor = PrimeActorFactory.CreatePrimeActor();
           return actor.GetPrimeList(DEFAULT_FROM, DEFAULT_TO);
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        //public Task<List<int>> Get([FromUri] PrimeIndexes indexes)
        //{
        //    List<int> listResult = new List<int>();
        //    listResult.Add(indexes.From);
        //    listResult.Add(indexes.To);
        //    return Task<List<int>>.FromResult(listResult);
        //}

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
