using System;
using System.Dynamic;

namespace SomeSamples.Chapter2
{
    public class Sample_2_29
    {
        public static void Do()
        {
            Console.WriteLine("DynamicObject");
            dynamic obj1 = new SampleObject();
            Console.WriteLine(obj1.SomeProperty);
            Console.WriteLine(obj1.Test);

            Console.WriteLine();

            Console.WriteLine("ExpandObject");
            dynamic obj2 = new ExpandoObject();
            obj2.Test = "AAAA";
            Console.WriteLine(obj2.Test);
            Console.WriteLine(obj2.Test.GetType());
        }

        public class SampleObject : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = binder.Name;
                return true;
            }
        }
    }
}