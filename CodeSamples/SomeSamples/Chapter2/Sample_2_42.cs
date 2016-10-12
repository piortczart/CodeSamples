using System;

namespace SomeSamples.Chapter2
{
    public class Sample_2_42
    {
        public static void Do()
        {
            Test test = new Test();
            Console.WriteLine(test.Value);
            test.Value = Int32.MaxValue;
            Console.WriteLine(test.Value);

            //(IReadOnlyProperty) test.Value = -1;
        }

        public class Test : IReadOnlyProperty
        {
            public int Value { get; set; }


            public void Foo()
            {
                throw new NotImplementedException();
            }
        }

        public interface IReadOnlyProperty : IFoo
        {
            int Value { get; }
        }

        public interface IFoo
        {
            void Foo();
        }
    }
}