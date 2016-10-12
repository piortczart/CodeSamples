using System;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Unsynchronized access by two threads.
    /// </summary>
    public class Sample_1_35_a
    {
        private static int Bad()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });
            for (int i = 0; i < 1000000; i++)
                n--;
            up.Wait();

            // n should be 0?
            return n;
        }

        public static void Do()
        {
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.ReadKey();
        }
    }
}