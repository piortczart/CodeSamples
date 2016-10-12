using System;
using System.Threading.Tasks;

namespace SomeSamples.Chapter1
{
    /// <summary>
    /// Breaking from a Parallel loop.
    /// </summary>
    public static class Sample_1_17
    {
        public static void Do()
        {
            ParallelLoopResult result = Parallel.For(0, 1000,
                (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        loopState.Break();
                    }
                    return;
                });

            Console.WriteLine("Completed: {0}, breaked at: {1} ", result.IsCompleted, result.LowestBreakIteration);

            Console.ReadKey();
        }
    }
}