using System;
using System.Threading;

namespace SomeSamples
{
    public static class Sample_1_04_b
    {
        /// http://yoda.arachsys.com/csharp/threads/shutdown.shtml
        public static void Do()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();

            Console.WriteLine("Pressanykeytoexit");
            Console.ReadKey();

            stopped = true;

            t.Join();
        }
    }
}
