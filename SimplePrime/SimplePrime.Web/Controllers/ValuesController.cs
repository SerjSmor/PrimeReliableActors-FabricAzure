using PrimeActor.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using SimplePrime.Common;

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
        public int Get(int numActors, int modActors)
        {

            return numActors + modActors;
            //var watch = System.Diagnostics.Stopwatch.StartNew();

            //List<Task> runners = new List<Task>();
            //List<int> resultsAggregate = new List<int>();

            //int range = 100000;
            //for (int i = 0; i < numActors; i++)
            //{
            //    int from = i * range;
            //    int to = (i + 1) * range;

            //    IPrimeActor primeActor = PrimeActorFactory.CreatePrimeActor(i);
            //    runners.Add(primeActor.GetPrimeList(from, to));
            //}

            //Task.WaitAll(runners.ToArray());

            //foreach (Task<List<int>> task in runners)
            //{
            //    List<int> results = task.GetAwaiter().GetResult();
            //    // aggregating all results from runners
            //    foreach (var num in results)
            //    {
            //        resultsAggregate.Add(num);
            //    }

            //    Console.WriteLine(String.Join(",", results));
            //}

            //watch.Stop();
            //string elapsed = watch.Elapsed.ToString();

            //PrimeResult primeResult = new PrimeResult();
            //primeResult.PrimeCount = resultsAggregate.Count;
            //primeResult.RequestDuration = elapsed;

            //return Task.FromResult(primeResult);
        }

        // GET api/values/5 
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        //public Task<List<int>> Get(PrimeIndexes indexes)
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
