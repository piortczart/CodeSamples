using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SomeSamples
{
    /// <summary>
    /// BlockingCollection - CompleteAdding makes sure nothing can be added anymore.
    /// </summary>
    public class Sample_1_29_a
    {
        public static void Do()
        {
            Console.WriteLine("Type stuff, press Enter. 'magic' is the magic word.");

            var collection = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in collection.GetConsumingEnumerable())
                    Console.WriteLine(v);

                Console.WriteLine("Reading finished.");
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) {
                        break;
                    }
                    if (input == "magic")
                    {
                        collection.CompleteAdding();
                    }
                    // Throw exception if 'magic'.
                    collection.Add(input);
                }
            });
            write.Wait();

            Console.ReadKey();
        }
    }
}
