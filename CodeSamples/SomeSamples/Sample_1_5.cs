using System;
using System.Threading;

namespace SomeSamples
{
    public static class Sample_1_5
    {
        [ThreadStatic]
        public static int Number;

        public static void Do()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    //Interlocked.Add(ref Number, 1);
                    Number++;
                    Console.WriteLine("ThreadA: {0}", Number);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    Number++;
                    Console.WriteLine("ThreadB: {0}", Number);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
