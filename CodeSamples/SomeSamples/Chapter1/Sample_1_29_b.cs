using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// BlockingCollection - with an upper limit.
    /// Communication logs?
    /// Show non-consumable iteration.
    /// </summary>
    public class Sample_1_29_b
    {
        public static void Do()
        {
            Console.WriteLine("Type stuff, press Enter. 'magic' is the magic word.");

            var collection = new BlockingCollection<string>(4);

            // Readin task...
            Task read = Task.Run(async () =>
            {
                //foreach (string v in collection)    // THIS WILL NOT CONSUME!
                foreach (string v in collection.GetConsumingEnumerable())
                {
                    Console.WriteLine("Read: {0}, count after read: {1}", v, collection.Count);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });

            Task write = Task.Run(() =>
            {
                for (int i = 0; i < 8; i++)
                {
                    collection.Add(i.ToString());
                    Console.WriteLine("Added: {0}", i);
                }
            });

            write.Wait();
            Console.WriteLine("Writing finished.");

            Console.ReadKey();
        }
    }
}