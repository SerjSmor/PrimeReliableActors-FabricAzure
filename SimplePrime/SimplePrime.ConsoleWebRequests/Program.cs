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
        private static readonly String CLUSTER_URL = "http://sense.eastus.cloudapp.azure.com";
        private static readonly String PORT = "19080";
        private static readonly String FULL_URL = CLUSTER_URL + ":" + PORT;
        private static readonly String REQUEST_STRING = "/simpleprime/api/values";

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(FULL_URL);
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.GetAsync(REQUEST_STRING).Result;

            if (response.IsSuccessStatusCode)
            {
                var numbers = response.Content.ReadAsAsync<List<int>>().Result;

                foreach (var number in numbers)
                {
                    Console.WriteLine("{0}", number);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
