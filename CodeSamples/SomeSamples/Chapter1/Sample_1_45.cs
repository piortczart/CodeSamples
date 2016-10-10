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
                Thread.Sleep(5000);
            });

            Console.WriteLine("Waiting a bit..");
            int index = Task.WaitAny(new[] { longRunning }, 1000);
            if (index == -1)
            {
                Console.WriteLine("Task timed out");
            }

            Console.WriteLine("Waiting 4 evah!");
            index = Task.WaitAny(new[] { longRunning });

            Console.WriteLine("Uff. Done, index: {0}", index);
            Console.ReadKey();
        }
    }
}
