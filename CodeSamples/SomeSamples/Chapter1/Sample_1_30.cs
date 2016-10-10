using System;
using System.Collections.Concurrent;

namespace SomeSamples
{
    public class Sample_1_30
    {
        public static void Do()
        {
            var bag = new ConcurrentBag<int> {42, 21};
            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            // TryPeek basically useless in multithreaded.
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
