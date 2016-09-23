using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SomeSamples
{
    public class Sample_1_29
    {
        public static void Do()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in col.GetConsumingEnumerable())
                    Console.WriteLine(v);

                Console.WriteLine("Reading finished.");
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    if (s == "magic")
                    {
                        col.CompleteAdding();
                        break;
                    }
                    col.Add(s);
                }
            });
            write.Wait();

            Console.ReadKey();
        }
    }
}
