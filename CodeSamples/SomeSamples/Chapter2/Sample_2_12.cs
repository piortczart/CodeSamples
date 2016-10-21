namespace SomeSamples.Chapter2
{
    public class Sample_2_12
    {
        class ConstructorChaining
        {
            private int _p;

            public ConstructorChaining() : this(3)
            {
            }

            public ConstructorChaining(int p)
            {
                this._p = p;
            }
        }
    }
}