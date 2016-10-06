using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_44
    {
        public static void Do()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            var task = Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                // Removing this line prevents the continuation from happenning.
                token.ThrowIfCancellationRequested();
            }, token)
                .ContinueWith(t =>
                {
                    //t.Exception.Handle(e=>true);
                    Console.WriteLine("Task was cancelled.");
                }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();

            Console.WriteLine("Waiting...");

            // No exception here!
            task.Wait();

            Console.WriteLine("Uff...");
            Console.ReadKey();
        }
    }
}
