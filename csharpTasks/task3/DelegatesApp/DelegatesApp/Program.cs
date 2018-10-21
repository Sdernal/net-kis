using System;

namespace DelegatesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market(new string[] { "Apple", "Google" });
            market.AddSubscriber(new Broker());
            for (int i = 0; i < 10; i++)
            {
                market.Trade();
            }

            PersonContainer container = new PersonContainer();
            container.People = new Person[]
            {
                new Person {Name="John", Age=19},
                new Person {Name="Alice", Age=21}
            };

            foreach (var p in container.GetAll(p => p.Age > 10))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
