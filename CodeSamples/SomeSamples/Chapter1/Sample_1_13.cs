using System;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    public static class Sample_1_13
    {
        public static void Do()
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0, TaskCreationOptions.AttachedToParent);
                tf.StartNew(() => results[1] = 1, TaskCreationOptions.AttachedToParent);
                tf.StartNew(() => results[2] = 2, TaskCreationOptions.AttachedToParent);
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