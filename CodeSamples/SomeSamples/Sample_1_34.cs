using System;
using System.Collections.Concurrent;

namespace SomeSamples
{
    public class Sample_1_34
    {
        public static void Do()
        {
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("[k1]: Added 42");
            }

            // Fails - key already there.
            if (!dict.TryAdd("k1", 100))
            {
                Console.WriteLine("[k1]: NOT added 100!");
            }

            Console.ReadKey();

            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("[k1]: 42 updated to 21");
            }

            // Fails - it is not 42 anymore.
            if (!dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("[k1]: 42 NOT updated to 21");
            }

            Console.ReadKey();

            dict["k1"] = 42; // Overwrite unconditionally

            int r0 = dict.AddOrUpdate("k0", 400, (s, i) => i * 2);
            Console.WriteLine("[k0]: AddOrUpdate0: " + r0);

            Console.ReadKey();

            // Will use the function to update the value.
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            Console.WriteLine("[k1]: AddOrUpdate1: " + r1);

            Console.ReadKey();

            // Adds 3, k2 not there.
            int r2 = dict.GetOrAdd("k2", 3);
            Console.WriteLine("[k2]: GetOrAdd: " + r2);

            Console.ReadKey();

            dict["k2"] = 600;
            // Gets, k2 already there.
            int r3 = dict.GetOrAdd("k2", 3);
            Console.WriteLine("[k2]: GetOrAdd: " + r3);

            Console.ReadKey();

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
