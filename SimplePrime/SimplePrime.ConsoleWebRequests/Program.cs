using SimplePrime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrime.ConsoleWebRequests
{
    class Program
    {
        private static readonly String CLUSTER_URL = "ENTER_CLUSTER_URL";
        private static readonly String LOCALHOST_URL = "http://localhost";

        private static readonly String PORT = "19080";
        private static readonly String FULL_URL = CLUSTER_URL + ":" + PORT;
        private static readonly String REQUEST_STRING = "/simpleprime/api/values/?numActors=";

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(FULL_URL);
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            // it's the number of the actors that will be initialsed in the cluster
            int numActors = 10;
            String FULL_REQUEST = REQUEST_STRING + numActors;
            HttpResponseMessage response = client.GetAsync(FULL_REQUEST).Result;

            if (response.IsSuccessStatusCode)
            {
                PrimeResult result = response.Content.ReadAsAsync<PrimeResult>().Result;
                Console.WriteLine("number of primes:{0}, duration time:{1}", result.PrimeCount, result.RequestDuration);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
