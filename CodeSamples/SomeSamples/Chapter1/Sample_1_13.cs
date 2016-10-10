using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// Factory with options.
    /// ExecuteSynchronously - continuations on the same thread.
    /// </summary>
    public static class Sample_1_13
    {
        public static void Do()
        {
            Task<int[]> parent = Task.Factory.StartNew(() =>
            //Task <int[]> parent = Task.Run(() =>
            {
                Console.WriteLine("Started the parent. Id: {0}", Thread.CurrentThread.ManagedThreadId);

                // All tasks created by this factory will attach to the parent.
                TaskFactory factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                var results = new int[3];
                factory.StartNew(() => results[0] = -1, TaskCreationOptions.AttachedToParent);
                // This task is a bit slow. :)
                Task slowTask = factory.StartNew(() =>
                {
                    Console.WriteLine("Slow child working... Id: {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                    results[1] = 1;
                }, TaskCreationOptions.AttachedToParent)
                .ContinueWith(t => { Console.WriteLine("The slow child is done. Id: {0}", Thread.CurrentThread.ManagedThreadId); });
                factory.StartNew(() => results[2] = 2, TaskCreationOptions.AttachedToParent);
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
