using System;
using System.Diagnostics;
using System.Linq;

namespace SomeSamples.Chapter1
{
    public class Sample_1_27
    {
        public static void Do()
        {
            var sw = Stopwatch.StartNew();

            var numbers = Enumerable.Range(0, 100);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("exceptions: {0}", e.InnerExceptions.Count);
            }

            Console.ReadKey();
        }

        private static bool IsEven(int i)
        {
            if (i%10 == 0)
            {
                throw new ArgumentException("i");
            }
            return i%2 == 0;
        }
    }
}