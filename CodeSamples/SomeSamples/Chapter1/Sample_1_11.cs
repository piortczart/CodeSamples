using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_11
    {
        public static void Do()
        {
            Task<int> t = Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 50))
                {
                    Console.Write("*");
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    // throw new Exception();
                }
                Console.WriteLine("");
                return 1;
            });

            t.ContinueWith((i) => { return i.Result + 1; }, TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith((i) =>
            {
                // Calling i.Result will throw the exception.
                //var x = i.Result;
                return 5;
            }, TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Result: " + t.Result);

            Console.ReadKey();
        }
    }
}