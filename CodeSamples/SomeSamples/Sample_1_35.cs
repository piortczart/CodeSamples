using System;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_35
    {
        private static int Bad()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });
            for (int i = 0; i < 1000000; i++)
                n--;
            up.Wait();

            return n;
        }

        public static void Do()
        {
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.WriteLine(Bad());
            Console.ReadKey();
        }
    }
}
