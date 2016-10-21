using System;
using System.Collections;
using System.Collections.Generic;

namespace SomeSamples.Chapter2
{
    public class Sample_2_56
    {
        public static void Do()
        {
            People people =
                new People(new[]
                {
                    new Person("a", "AA"),
                    new Person("b", "BB"),
                    new Person("c", "CC"),
                    new Person("f", "FF"),
                    new Person("d", "DD")
                });

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        class People : IEnumerable<Person>
        {
            public People(Person[] people)
            {
                this.people = people;
            }

            Person[] people;

            public IEnumerator<Person> GetEnumerator()
            {
                for (int index = 0; index < people.Length; index++)
                {
                    yield return people[index];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}