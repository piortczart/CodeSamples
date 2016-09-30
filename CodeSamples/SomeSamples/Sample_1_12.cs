﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_12
    {
        public static void Do()
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];
                new Task(() => results[0] = -1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() =>
                {
                    Thread.Sleep(1000); results[1] = 1;
                }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            Task finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine(i);
                    }
                });

            finalTask.Wait();

            Console.ReadKey();
        }
    }
}
