using System;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_36
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
