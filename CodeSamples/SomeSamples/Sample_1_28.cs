using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_28
    {
        public static void Do()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();

            Console.ReadKey();
        }
    }
}
