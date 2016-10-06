using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public static class Sample_1_10
    {
        /// <summary>
        /// Continuation task thread id.
        /// </summary>
        public static void Do()
        {
            Task<int> t = Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 10))
                {
                    Console.Write("*");
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Console.WriteLine("{1}First task part thread ID: {0}", Thread.CurrentThread.ManagedThreadId, Environment.NewLine);
                return 1;
            }).ContinueWith((i) =>
            {
                Console.WriteLine("First task result: {0}. Continuing the task.", i.Result);
                Console.WriteLine("Continutaion task thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
                return i.Result + 5;
            });

            Console.WriteLine("Final result: " + t.Result);

            Console.ReadKey();
        }
    }
}
