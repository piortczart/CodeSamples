using System;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Sunchronized access by two threads?
    /// http://stackoverflow.com/questions/154551/volatile-vs-interlocked-vs-lock
    /// </summary>
    public class Sample_1_35_b
    {
        static volatile int n = 0;

        private static int Volatile()
        {
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
            Console.WriteLine(Volatile());
            Console.WriteLine(Volatile());
            Console.WriteLine(Volatile());
            Console.WriteLine(Volatile());
            Console.WriteLine(Volatile());
            Console.ReadKey();
        }
    }
}