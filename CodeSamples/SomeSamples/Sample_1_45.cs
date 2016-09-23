using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_45
    {
        public static void Do()
        {
            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            int index = Task.WaitAny(new[] { longRunning }, 1000);
            if (index == -1)
                Console.WriteLine("Task timed out");

            Console.WriteLine("Waiting...");
            longRunning.Wait();

            Console.WriteLine("Uff.");
            Console.ReadKey();
        }
    }
}
