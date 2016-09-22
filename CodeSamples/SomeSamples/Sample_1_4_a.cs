using System;
using System.Threading;

namespace SomeSamples
{
    public static class Sample_1_4_a
    {
        public static void ThreadMethod(object thing)
        {
            for (int i = 0; i < (int)thing; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
            }
        }

        public static void Do()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(50);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            t.Abort();

            Console.ReadKey();
        }
    }
}
