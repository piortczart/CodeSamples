﻿using System;
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
                Console.WriteLine("Added");
            }

            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dict["k1"] = 42; // Overwrite unconditionally
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            Console.WriteLine("AddOrUpdate: " + r1);
            int r2 = dict.GetOrAdd("k2", 3);
            Console.WriteLine("GetOrAdd: " + r2);

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
