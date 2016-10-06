using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_11
    {
        /// <summary>
        /// OnFaulted continuation.
        /// Show what happens when line 37 gets uncommented.
        /// </summary>
        public static void Do()
        {
            Task<int> task = Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 50))
                {
                    Console.Write("*");
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    if (i > 20)
                    {
                        Console.WriteLine("");
                        throw new Exception("That's too much.");
                    }
                }
                return 1;
            });

            // Notice the new variable.
            Task<int> continuation = task.ContinueWith((i) =>
            {
                Console.WriteLine("Last task threw an exception. Type: {0}, inner message: {1}",
                    i.Exception.GetType().FullName, i.Exception.InnerException.Message);

                // Calling i.Result will throw the exception here.
                //int x = i.Result;
                return 5;
            }, TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Final result: " + continuation.Result);

            Console.ReadKey();
        }
    }
}
