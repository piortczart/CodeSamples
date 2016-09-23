using System;

namespace SomeSamples
{
    public class Sample_1_39
    {
        private static int _flag = 0;
        private static int _value = 0;

        public static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }
        public static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }

        public static void Do()
        {
            // http://stackoverflow.com/questions/154551/volatile-vs-interlocked-vs-lock

            Console.ReadKey();
        }
    }
}
