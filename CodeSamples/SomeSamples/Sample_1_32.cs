using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_32
    {
        public static void Do()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);

            stack.PushRange(new[] { 1, 2, 3 });
            var values = new int[2];
            stack.TryPopRange(values);
            foreach (int i in values)
                Console.WriteLine(i);

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
