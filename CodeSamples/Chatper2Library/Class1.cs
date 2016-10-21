using SomeSamples.Chapter2;

namespace Chatper2Library
{
    public class Sample_2_31
    {
        public class SampleA
        {
            public void Foo()
            {
                AccessModifiersTestClass sample231 = new AccessModifiersTestClass();
                sample231.ProperyPublic = -1;

                // InternalsVisibleTo 
                SomeSamples.Chapter2.InternalClass internalClass = new InternalClass();

                PublicClass publicClass = new PublicClass();
                PublicClass.ProtectedInternalClass protectedInternalClass = new PublicClass.ProtectedInternalClass();
                PublicClass.PublicClassInner publicClassInner = new PublicClass.PublicClassInner();
                PublicClass.IPublicInterface publicInterface;
                PublicClass.PublicEnum publicEnum;
            }
        }

        public class SampleB : AccessModifiersTestClass
        {
            public void Foo()
            {
                PropertyProtected = -1;
                PropertyProtectedInternal = -1;
                ProperyPublic = -1;
            }
        }
    }
}