using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_09
    {
        public static void Do()
        {
            Task<int> t = Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 100))
                {
                    Console.Write("*");
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
                Console.WriteLine("");
                return 1;
            });

            Console.WriteLine("Result: " + t.Result);

            Console.ReadKey();
        }
    }
}