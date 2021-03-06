﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Making decisions based on a value shared by two threads...
    /// </summary>
    public class Sample_1_41
    {
        static int value = 1;

        public static void Do()
        {
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output
                    Thread.Sleep(500);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() => { value = 3; });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value); // Displays 2

            Console.ReadKey();

            //Interlocked.CompareExchange(ref value, 10, 3);
        }
    }
}