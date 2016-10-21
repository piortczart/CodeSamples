using System;
using System.Diagnostics;
using System.Linq;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Parallel Linq Vs Linq.
    /// A good and a bad example.
    /// </summary>
    public class Sample_1_22
    {
        public static void Do()
        {
            var sw = Stopwatch.StartNew();

            Func<int, long> goodOne = FindPrimeNumber;
            Func<int, long> badOne = i => { return i%2; };

            Func<int, long> calculation = goodOne; // CHANGE HERE.

            var numbers = Enumerable.Range(0, 4000);
            numbers.AsParallel().Select(calculation).ToArray();

            Console.WriteLine("PLINQ: {0}", sw.Elapsed);

            sw.Restart();

            numbers.Select(calculation).ToArray();

            Console.WriteLine("LINQ: {0}", sw.Elapsed);
            Console.ReadKey();
        }

        /// <summary>
        /// Find nth prime. Taken from the interwebz.
        /// </summary>
        public static long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1; // to check if found a prime
                while (b*b <= a)
                {
                    if (a%b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                    count++;
                a++;
            }
            return (--a);
        }
    }
}