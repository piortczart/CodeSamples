using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// Attaching child tasks example. One child has a continuation task.
    /// Show what happens when we run Task.Run() instead of Task.Factory.
    /// </summary>
    public static class Sample_1_12
    {
        public static void Do()
        {
            Task<int[]> parent = Task.Factory.StartNew(() =>
                //Task <int[]> parent = Task.Run(() =>
            {
                Console.WriteLine("Started the parent. Id: {0}", Thread.CurrentThread.ManagedThreadId);

                var results = new int[3];
                new Task(() => results[0] = -1, TaskCreationOptions.AttachedToParent).Start();
                // This task is a bit slow. :)
                Task slowTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Slow child working... Id: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                    results[1] = 1;
                }, TaskCreationOptions.AttachedToParent)
                    .ContinueWith(
                        t =>
                        {
                            Console.WriteLine("The slow child is done. Id: {0}", Thread.CurrentThread.ManagedThreadId);
                        });
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            // This task will be run only when all child tasks of the parent task finish.
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