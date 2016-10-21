using System;
using System.Diagnostics;
using System.Linq;

namespace SomeSamples
{
    /// <summary>
    /// PLinq - order is not enforced by default.
    /// </summary>
    public class Sample_1_23
    {
        public static void Do()
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine("Unordered...");
            var numbers = Enumerable.Range(0, 20).ToList();
            int[] parallelResult = numbers.AsParallel().Where(i => i%2 == 0).ToArray();
            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

            Console.WriteLine("Oooooorder!");
            parallelResult = numbers.AsParallel().AsOrdered().Where(i => i%2 == 0).ToArray();
            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}