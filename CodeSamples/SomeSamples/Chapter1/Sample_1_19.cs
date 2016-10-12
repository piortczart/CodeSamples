using System;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    public class Sample_1_19
    {
        public static void Do()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// This actually wastes a thread. Non-async stuff packed in a task.
        /// </summary>
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        /// <summary>
        /// Uses a timer - does not waste a thread.
        /// </summary>
        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer((x) => { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}