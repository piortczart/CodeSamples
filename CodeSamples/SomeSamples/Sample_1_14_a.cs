using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// A simple WaitAll...
    /// </summary>
    public static class Sample_1_14_a
    {
        public static void Do()
        {
            var stopwatch = Stopwatch.StartNew();

            var tasks = new Task[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("1"); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1500); Console.WriteLine("2"); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("3"); return 3; });

            Task.WaitAll(tasks);

            Console.WriteLine(stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
