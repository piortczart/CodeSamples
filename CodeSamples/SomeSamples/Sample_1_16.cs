using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_16
    {
        public static void Do()
        {
            var stopwatch = Stopwatch.StartNew();

            Parallel.ForEach(Enumerable.Range(0, 8), i => { Thread.Sleep(1000); });

            Console.WriteLine("First: " + stopwatch.Elapsed);
            stopwatch.Restart();

            Parallel.For(0, 8, i => { Thread.Sleep(1000); });

            Console.WriteLine("Second: " + stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
