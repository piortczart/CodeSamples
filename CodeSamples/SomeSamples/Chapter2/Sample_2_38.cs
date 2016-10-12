using System;
using System.ComponentModel;

namespace SomeSamples.Chapter2
{
    public class Sample_2_38
    {
        public static void Do()
        {
            Test test = new Test();
            test.Foo();
            ITest1 test1 = test;
            test1.Foo();
            (test as ITest2).Foo();
        }

        public class Test : ITest1, ITest2, ITest3
        {
            void ITest1.Foo()
            {
                Console.WriteLine("ITest1.Foo");
            }

            void ITest2.Foo()
            {
                Console.WriteLine("ITest2.Foo");
            }

            public void Foo()
            {
                Console.WriteLine("ITest3.Foo");
            }
        }
    }

    public interface ITest1
    {
        void Foo();
    }

    public interface ITest2
    {
        void Foo();
    }

    public interface ITest3
    {
        void Foo();
    }
}