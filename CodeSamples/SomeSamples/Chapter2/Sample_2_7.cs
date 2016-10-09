using System;

namespace SomeSamples.Chapter2
{
    // Using named and optional arguments
    class Sample_2_7
    {
        public static void Do()
        {
            CallingMethod();
        }

        private static void MyMethod(int firstArgument, string secondArgument = "default value",
            bool thirdArgument = false)
        {
            Console.WriteLine("firstArgument: " + firstArgument);
            Console.WriteLine("secondArgument: " + secondArgument);
            Console.WriteLine("thirdArgument: " + thirdArgument);
        }

        private static void CallingMethod()
        {
            MyMethod(1, thirdArgument: true);
        }
    }
}