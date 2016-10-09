using System;
using System.Threading;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_2
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Do()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            //t.IsBackground = false;
            t.Start();
        }
    }
}