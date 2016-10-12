using System.Security.Policy;

namespace SomeSamples.Chapter2
{
    public class Sample_2_2
    {
        public static void Do()
        {
        }

        public struct Point
        {
            public int x, y;

            //public Point()
            //{

            //}

            //public int z = 0;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }

        //public struct Point3D : Point
        //{
        //    public int z;
        //}
    }
}