using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrime.ConsolePrimeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int batchMax = 5;
            int range = 100000;
            List<int> aggregateResults = new List<int>();

            Parallel.For(0, batchMax, i => 
            {
                int from = i * range;
                int to = (i + 1) * range;

                List<int> results = GetPrimeList(from, to);
                foreach (int num in results)
                {
                    aggregateResults.Add(num);
                }
            
            });
            //{
            //    int from = i * range;
            //    int to = (i + 1) * range;

            //    List<int> results = GetPrimeList(from, to);
            //    foreach (int num in results)
            //    {
            //        aggregateResults.Add(num);
            //    }
            //}

            //Task.WaitAll(runners.ToArray());

            //foreach (Task<List<int>> task in runners)
            //{
            //    List<int> results = task.GetAwaiter().GetResult();
            //    Console.WriteLine(String.Join(",", results));
            //}

            watch.Stop();
            string elapsed = watch.Elapsed.ToString();

            Console.WriteLine("elpased:{0}", elapsed);
        }

        public static List<int> GetPrimeList(int from, int to)
        {
            List<int> resultList = new List<int>();
            for (int k = from; k < to; k++)
            {
                int loopLength = k / 2;
                bool isPrime = true;
                int i = 2;

                while (i <= loopLength && isPrime)
                {
                    int modResult = k % i;

                    if (modResult == 0)
                    {
                        isPrime = false;
                    }

                    i++;
                }
                if (isPrime)
                {
                    Console.WriteLine("is prime:{0}", k);
                    resultList.Add(k);
                }


            }
            return resultList;
        }
    }
}
