using System;
using System.Threading;

namespace SomeSamples
{
    public static class Sample_1_01
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                //Thread.Sleep(0);
            }
        }

        public static void Do()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Mainthread: Dosomework.");
                //Thread.Sleep(0);
            }
            t.Join();

            Console.ReadKey();
        }
    }
}
