using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_10
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
            }).ContinueWith((i) =>
            {
                return i.Result + 5;
            });

            Console.WriteLine("Result: " + t.Result);

            Console.ReadKey();
        }
    }
}
