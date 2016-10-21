using System;

namespace SomeSamples.Chapter2
{
    public class Sample_2_24
    {
        public static void Do()
        {
            Money money = new Money(432.1m);
            Console.WriteLine(money + 100.0m);
            Console.WriteLine(money + 100);
        }

        class Money
        {
            public Money(decimal amount)
            {
                Amount = amount;
            }

            public decimal Amount { get; set; }

            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }

            public static explicit operator int(Money money)
            {
                return (int) money.Amount;
            }
        }
    }
}