using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// Count, TryTake, TryPeek.
    /// </summary>
    public class Sample_1_31_b
    {
        public static void Do()
        {
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                bag.Add(55);
                // Adding the last element will take too long. We will not get it.
                Thread.Sleep(1000);
                bag.Add(21);
            });

            // Make sure stuff is added.
            Thread.Sleep(100);

            Task.Run(() =>
            {
                int i;
                while (bag.TryTake(out i))
                {
                    Console.WriteLine("Taken item: {0}, count: {1}", i, bag.Count);
                }
            }).Wait();

            // Wait for the last element and just TryPeek it.
            Thread.Sleep(1000);
            int j;
            if (bag.TryPeek(out j))
            {
                Console.WriteLine("Peeked last element: {0}, count: {1}", j, bag.Count);
            }

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
