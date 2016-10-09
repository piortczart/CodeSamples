using System;
using System.Threading;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_7
    {
        static int blabla = 0;

        public static void Do()
        {
            while (true)
            {
                ThreadPool.QueueUserWorkItem((s) =>
                {
                    Console.WriteLine("Pool {0}", blabla);
                    Interlocked.Add(ref blabla, 1);
                });
            }
        }
    }
}