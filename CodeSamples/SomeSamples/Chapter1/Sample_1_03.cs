using System;
using System.Threading;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_03
    {
        public static void ThreadMethod(object thing)
        {
            for (int i = 0; i < (int) thing; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep(100);
            }
        }

        public static void Do()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(50);

            Console.ReadKey();
        }
    }
}