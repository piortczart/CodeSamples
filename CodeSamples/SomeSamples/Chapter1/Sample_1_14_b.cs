using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// WaitAll with a timeout.
    /// </summary>
    public static class Sample_1_14_b
    {
        public static void Do()
        {
            var stopwatch = Stopwatch.StartNew();

            var tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            bool isOk1 = Task.WaitAll(tasks, 1100); // Nope
            bool isOk2 = Task.WaitAll(tasks, 500); // OK

            Console.WriteLine("First try: {0}, second: {1}, total time: {2}", isOk1, isOk2, stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}