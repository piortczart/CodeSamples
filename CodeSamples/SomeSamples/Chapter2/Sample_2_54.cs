using System;
using System.Collections.Generic;

namespace SomeSamples.Chapter2
{
    public class Sample_2_54
    {
        public static void Do()
        {
            List<Group> groups = new List<Group>
            {
                new Group {Level = 1, Letter = "A"},
                new Group {Level = 3, Letter = "d"},
                new Group {Level = 2, Letter = "A"},
                new Group {Level = 2, Letter = "H"},
                new Group {Level = 2, Letter = "t"},
                new Group {Level = 1, Letter = "B"},
            };
            groups.Sort();
            foreach (Group g in groups)
            {
                Console.WriteLine(g);
            }
        }

        private class Group : IComparable, IComparable<Group>
        {
            public int Level { get; set; }
            public string Letter { get; set; }

            public int CompareTo(object obj)
            {
                Group g = obj as Group;
                if (g == null)
                {
                    throw new ArgumentException();
                }

                return this.Level.CompareTo(g.Level)*100 +
                       String.Compare(this.Letter, g.Letter, StringComparison.OrdinalIgnoreCase);
            }

            public int CompareTo(Group other)
            {
                return CompareTo((object) other);
            }

            public override string ToString()
            {
                return $"Level: {Level}, Letter: {Letter}";
            }
        }
    }
}