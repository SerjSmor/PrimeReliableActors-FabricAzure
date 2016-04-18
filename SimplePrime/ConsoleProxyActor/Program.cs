using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using PrimeActor.Interfaces;
using System.Fabric;

namespace ConsoleProxyActor
{
    class Program
    {
        private static readonly string SERVICE_NAME = "fabric:/SimplePrime/PrimeActorService";
        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();


            //ActorRuntime.RegisterActorAsync<PrimeActor.PrimeActor>(
            //      (context, actorType) => new ActorService(context, actorType, () => new PrimeActor.PrimeActor())).GetAwaiter().GetResult();

            var fruntime = FabricRuntime.Create();

            List<Task> runners = new List<Task>();
            int batchMax = 5;
            Uri uri = new Uri(SERVICE_NAME);
            int range = 200000;
            for (int i = 0; i < batchMax; i++)
            {
                int from = i * range;
                int to = (i + 1) * range;

                ActorId actorId = ActorId.CreateRandom();
                IPrimeActor primeActor = ActorProxy.Create<IPrimeActor>(actorId, uri);
                runners.Add(primeActor.GetPrimeList(from, to));
            }

            Task.WaitAll(runners.ToArray());

            foreach (Task<List<int>> task in runners)
            {
                List<int> results = task.GetAwaiter().GetResult();
                Console.WriteLine(String.Join(",", results));
            }

            watch.Stop();
            string elapsed = watch.Elapsed.ToString();
            System.Diagnostics.Debug.WriteLine(elapsed);

        }
    }
}
