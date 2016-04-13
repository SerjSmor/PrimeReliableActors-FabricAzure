using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using PrimeActor.Interfaces;
using System.Collections.Generic;

namespace PrimeActor
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        /// 
        private static readonly string SERVICE_NAME = "fabric:/SimplePrime/PrimeActorService";

        private static void Main()
        {
            try
            {
                // This line registers an Actor Service to host your actor class with the Service Fabric runtime.
                // The contents of your ServiceManifest.xml and ApplicationManifest.xml files
                // are automatically populated when you build this project.
                // For more information, see http://aka.ms/servicefabricactorsplatform

                ActorRuntime.RegisterActorAsync<PrimeActor>(
                   (context, actorType) => new ActorService(context, actorType, () => new PrimeActor())).GetAwaiter().GetResult();

                //var watch = System.Diagnostics.Stopwatch.StartNew();

                //List<Task> runners = new List<Task>();
                //int batchMax = 5;
                //Uri uri = new Uri(SERVICE_NAME);
                //int range = 100000;
                //for (int i = 0; i < batchMax; i++)
                //{
                //    int from = i * range;
                //    int to = (i + 1) * range;

                //    ActorId actorId = ActorId.CreateRandom();
                //    IPrimeActor primeActor = ActorProxy.Create<IPrimeActor>(actorId, uri);
                //    runners.Add(primeActor.GetPrimeList(from, to));
                //}

                //Task.WaitAll(runners.ToArray());

                //foreach (Task<List<int>> task in runners)
                //{
                //    List<int> results = task.GetAwaiter().GetResult();
                //    Console.WriteLine(String.Join(",", results));
                //}

                //watch.Stop();
                //string elapsed = watch.Elapsed.ToString();
                //System.Diagnostics.Debug.WriteLine(elapsed);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
