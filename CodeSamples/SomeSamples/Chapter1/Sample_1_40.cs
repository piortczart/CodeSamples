using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// SKIP!
    /// </summary>
    public class Sample_1_40
    {
        public static void Do()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);
            up.Wait();
            Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}