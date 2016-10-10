using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SomeSamples.Chapter2
{
    public class Sample_2_10
    {
        public static void Do()
        {
            Deck deck = new Deck();
            Random rand = new Random();
            foreach (int i in Enumerable.Range(1, 100))
            {
                deck.Cards.Add(new Card(rand.Next()));
            }

            Console.WriteLine(deck[50]);
        }
    }

    class Card
    {
        private readonly int _i;

        public Card(int i)
        {
            _i = i;
        }

        public override string ToString()
        {
            return _i.ToString();
        }
    }

    class Deck
    {
        public ICollection<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new Collection<Card>();
        }


        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
    }
}