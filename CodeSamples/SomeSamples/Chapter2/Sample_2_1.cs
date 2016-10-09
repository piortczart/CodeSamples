using System;

namespace SomeSamples.Chapter2
{
    // Show with Flags attribute and commented
    public class Sample_2_1
    {
        public static void Do()
        {
            const Days weekend = Days.Saturday | Days.Sunday;
            Console.WriteLine(weekend);
        }

        [Flags]
        enum Days
        {
            None = 0,
            Sunday = 1,
            Monday = 2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }
    }
}