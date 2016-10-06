using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// A BlockingCollection example.
    /// </summary>
    public class Sample_1_28
    {
        public static void Do()
        {
            Console.WriteLine("Type, press enter. Repeat.");

            var collection = new BlockingCollection<string>();
            // This will consume whatever we feed it.
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(collection.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    // Read the console.
                    string s = Console.ReadLine();
                    // Wait for empty char.
                    if (string.IsNullOrWhiteSpace(s)) break;
                    collection.Add(s);
                }
            });
            write.Wait();

            Console.WriteLine("We're DONE!");
            Console.ReadKey();
        }
    }
}
