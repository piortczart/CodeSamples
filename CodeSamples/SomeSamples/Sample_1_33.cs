using System;
using System.Collections.Concurrent;

namespace SomeSamples
{
    public class Sample_1_33
    {
        public static void Do()
        {
            var queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued: {0}", result);

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
