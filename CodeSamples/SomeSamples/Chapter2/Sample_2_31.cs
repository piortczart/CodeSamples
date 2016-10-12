using System;

namespace SomeSamples.Chapter2
{
    public class Sample_2_31
    {
        public static void Do()
        {
            AccessModifiersTestClass testClass = new AccessModifiersTestClass();
            testClass.PropertyProtectedInternal = -1;
            testClass.Propertynternal = -1;
            testClass.ProperyPublic = -1;

            Console.WriteLine(testClass);
        }
    }

    public class AccessModifiersTestClass
    {
        public int ProperyPublic { get; set; }
        protected int PropertyProtected { get; set; }
        protected internal int PropertyProtectedInternal { get; set; }
        internal int Propertynternal { get; set; }
        private int PropertyInt { get; set; }

        public override string ToString()
        {
            return
                $"ProperyPublic: {ProperyPublic},\nPropertyProtected: {PropertyProtected},\nPropertyProtectedInternal: {PropertyProtectedInternal},\nPropertynternal: {Propertynternal},\nPropertyInt: {PropertyInt}";
        }
    }
}