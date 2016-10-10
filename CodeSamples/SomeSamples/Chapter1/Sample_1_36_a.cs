using System;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// Synchronized access.
    /// </summary>
    public class Sample_1_36_a
    {
        private static int Good()
        {
            object locker = new object();

            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    lock (locker)
                        n++;
            });
            for (int i = 0; i < 1000000; i++)
                lock (locker)
                    n--;
            up.Wait();

            return n;
        }

        public static void Do()
        {
            Console.WriteLine(Good());
            Console.WriteLine(Good());
            Console.WriteLine(Good());
            Console.WriteLine(Good());
            Console.WriteLine(Good());
            Console.ReadKey();
        }
    }
}
