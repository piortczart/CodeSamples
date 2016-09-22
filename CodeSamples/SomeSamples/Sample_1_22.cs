using System;
using System.Diagnostics;
using System.Linq;

namespace SomeSamples
{
    public class Sample_1_22
    {
        public static void Do()
        {
            var sw = Stopwatch.StartNew();

            var numbers = Enumerable.Range(0, 100000000);
            int[] parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            Console.WriteLine("PLINQ: {0}",  sw.Elapsed);

            foreach (int i in parallelResult) Console.WriteLine(i);

            int[] regularResult = numbers.Where(i => i % 2 == 0).ToArray();

            Console.WriteLine("LINQ: {0}", sw.Elapsed);
            Console.ReadKey();
        }
    }
}
