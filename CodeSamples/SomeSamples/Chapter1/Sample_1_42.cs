using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// CancellationTokenSource
    /// </summary>
    public class Sample_1_42
    {
        public static void Do()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(2000);
                }
            }, token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();

            Console.WriteLine("Waiting...");
            task.Wait();

            Console.WriteLine("Uff... Done.");
            Console.ReadKey();
        }
    }
}