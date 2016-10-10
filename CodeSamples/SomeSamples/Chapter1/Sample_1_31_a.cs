using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// A very simple ConcurrentBag demo.
    /// </summary>
    public class Sample_1_31_a
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
                // Getting stuff out does not block. We will not wait for the last element.
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();


            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
