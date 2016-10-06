using System;
using System.Collections.Concurrent;

namespace SomeSamples
{
    /// <summary>
    /// ConcurrentQueue - non-blocking FIFO
    /// </summary>
    public class Sample_1_33
    {
        public static void Do()
        {
            var queue = new ConcurrentQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(15);

            int result;
            while (queue.TryDequeue(out result))
            {
                Console.WriteLine("Dequeued: {0}, count: {1}", result, queue.Count);
            }

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
