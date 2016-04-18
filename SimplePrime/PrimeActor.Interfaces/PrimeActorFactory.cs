using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeActor.Interfaces
{
    public static class PrimeActorFactory
    {
        private static readonly Uri uri = new Uri("fabric:/SimplePrime/PrimeActorService");

        public static IPrimeActor CreatePrimeActor()
        {
            ActorId actorId = ActorId.CreateRandom();
            IPrimeActor primeActor = ActorProxy.Create<IPrimeActor>(actorId, uri);
            return primeActor;
        }
    }
}
