using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_19
    {
        public static void Do()
        {

            Console.ReadKey();
        }

        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer((x)=> { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}
