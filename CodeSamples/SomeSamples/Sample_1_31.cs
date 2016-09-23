using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_31
    {
        public static void Do()
        {
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                bag.Add(55);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            // Make sure stuff is added.
            Thread.Sleep(100);

            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
