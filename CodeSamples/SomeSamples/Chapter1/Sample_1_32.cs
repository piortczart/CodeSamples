using System;
using System.Collections.Concurrent;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// ConcurrentStack - a non-blocking FILO
    /// </summary>
    public class Sample_1_32
    {
        public static void Do()
        {
            var stack = new ConcurrentStack<int>();
            int first = 42;
            stack.Push(first);
            Console.WriteLine("Pushed: {0}", first);
            Console.ReadKey();

            int result;
            if (stack.TryPop(out result))
            {
                Console.WriteLine("Popped (single pop): {0}", result);
            }

            Console.ReadKey();

            var toPush = new[] {1, 2};
            Console.WriteLine("Pushing items: {0}", String.Join(",", toPush));
            stack.PushRange(toPush);
            Console.WriteLine("Pushing an extra item: 3");
            stack.Push(3);
            Console.WriteLine("Count: {0}", stack.Count);

            Console.ReadKey();

            // Only 2 spots.
            var values = new int[2];
            int popedCount1 = stack.TryPopRange(values);
            Console.WriteLine("Popped (range pop) count: {0}", popedCount1);

            Console.ReadKey();

            foreach (int i in values)
                Console.WriteLine("Popped item: {0}", i);

            Console.ReadKey();

            // Last range pop.
            int popedCount2 = stack.TryPopRange(values);
            Console.WriteLine("Popped (range pop) count: {0}", popedCount2);
            Console.ReadKey();
            foreach (int i in values)
                Console.WriteLine("Popped item: {0}", i);

            Console.WriteLine("Why 2 items in 'values'?");

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}