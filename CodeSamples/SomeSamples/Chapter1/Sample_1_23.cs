using System;
using System.Diagnostics;
using System.Linq;

namespace SomeSamples.Chapter1
{
    public class Sample_1_23
    {
        public static void Do()
        {
            var sw = Stopwatch.StartNew();

            var numbers = Enumerable.Range(0, 100);
            int[] parallelResult = numbers.AsParallel().Where(i => i%2 == 0).ToArray();
            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

            // Ordered.
            parallelResult = numbers.AsParallel().AsOrdered().Where(i => i%2 == 0).ToArray();
            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}