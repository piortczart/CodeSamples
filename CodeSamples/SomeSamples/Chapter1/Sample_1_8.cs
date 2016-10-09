using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_8
    {
        public static void Do()
        {
            Task t = Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 1000))
                {
                    Console.Write("*");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });

            //t.Wait();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}