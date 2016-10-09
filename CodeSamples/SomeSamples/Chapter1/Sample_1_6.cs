using System;
using System.Threading;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_6
    {
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() => { return Thread.CurrentThread.ManagedThreadId; });

        public static void Do()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.WriteLine("ThreadA: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.WriteLine("ThreadB: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}