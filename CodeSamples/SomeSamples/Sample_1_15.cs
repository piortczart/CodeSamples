using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// Analyze the results of many tasks from an array.
    /// Notice the changing indexes because of array rebuliding!
    /// </summary>
    public static class Sample_1_15
    {
        public static void Do()
        {
            var stopwatch = Stopwatch.StartNew();

            var tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(3000); Console.WriteLine("Finished: 0"); return 0; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1500); Console.WriteLine("Finished: 1"); return 1; });
            tasks[2] = Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("Finished: 2"); return 2; });

            while (tasks.Length > 0)
            {
                // Returns the index of the task which has finished.
                int taskIndex = Task.WaitAny(tasks);
                // Show the task's result (it should show it immediatelly)
                Task<int> completedTask = tasks[taskIndex];
                Console.WriteLine("Task with index {0} result: {1}", taskIndex, completedTask.Result);

                // "Remove" the finished task from the array. Not too pretty.
                List<Task<int>> temp = tasks.ToList();
                temp.RemoveAt(taskIndex);
                tasks = temp.ToArray();
            }

            Console.WriteLine(stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
