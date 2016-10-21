using System;

namespace SomeSamples.Chapter2
{
    public class Sample_2_18
    {
        public static void Do()
        {
            A a = new A();
            B b = new B();
            C c = new C();

            a.Show();
            b.Show();
            c.Show();

            Console.WriteLine();

            (a as A).Show();
            (b as A).Show();
            (c as A).Show();

            Console.WriteLine();

            a = b;
            a.Show();
            a = c;
            a.Show();
        }
    }

    public class A
    {
        public virtual void Show()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A
    {
        public override void Show()
        {
            Console.WriteLine("B");
        }
    }

    public class C : A
    {
        public new void Show()
        {
            Console.WriteLine("C");
        }
    }
}