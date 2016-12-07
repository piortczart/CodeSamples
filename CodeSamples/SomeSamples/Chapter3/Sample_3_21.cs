using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SomeSamples.Chapter3
{
    public class Sample_3_21
    {
        /// <summary>
        /// Naiive unscaleable comparison.
        /// </summary>
        class Set<T>
        {
            private readonly List<T> _list = new List<T>();

            public void Insert(T item)
            {
                if (!Contains(item))
                    _list.Add(item);
            }

            public bool Contains(T item)
            {
                foreach (T member in _list)
                    if (member.Equals(item))
                        return true;
                return false;
            }
        }

        public static void Do()
        {
            var time = Stopwatch.StartNew();

            var set = new Set<Set<int>>();
            for (int i = 0; i < 20000; i++)
            {
                set.Insert(new Set<int>());
            }

            Console.WriteLine("Time taken: " + time.Elapsed);
        }
    }
}