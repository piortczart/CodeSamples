using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SomeSamples.Chapter3
{
    public class Sample_3_22
    {
        class Set<T>
        {
            private readonly List<T>[] _buckets = new List<T>[100];

            public void Insert(T item)
            {
                int bucket = GetBucket(item.GetHashCode());
                if (Contains(item, bucket))
                    return;
                if (_buckets[bucket] == null)
                    _buckets[bucket] = new List<T>();
                _buckets[bucket].Add(item);
            }

            public bool Contains(T item)
            {
                return Contains(item, GetBucket(item.GetHashCode()));
            }

            private int GetBucket(int hashcode)
            {
                // A Hash code can be negative. To make sure that you end up with a positive
                // value cast the value to an unsigned int. The unchecked block makes sure that
                // you can cast a value larger then int to an int safely.
                unchecked
                {
                    return (int) ((uint) hashcode%(uint) _buckets.Length);
                }
            }

            private bool Contains(T item, int bucket)
            {
                if (_buckets[bucket] != null)
                    foreach (T member in _buckets[bucket])
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