using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Deadlock!
    /// </summary>
    public class Sample_1_37
    {
        public static void Do()
        {
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            Thread.Sleep(100);

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }
            up.Wait();

            Console.WriteLine("Will I get here?");
            Console.ReadKey();
        }
    }
}