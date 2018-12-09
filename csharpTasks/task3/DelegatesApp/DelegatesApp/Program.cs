using System;

namespace DelegatesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market(new[]
            {
                "Apple", "Google", "Bitcoin"
            });
            Broker broker = new Broker();
            RandomTrader randomTrader = new RandomTrader();
            market.AddSubscriber(broker);
            market.AddSubscriber(randomTrader);

            Console.WriteLine(broker);
            Console.WriteLine(randomTrader);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Trade #{i + 1}\n");
                market.Trade();
                Console.WriteLine(broker);
                Console.WriteLine(randomTrader);
            }

            PersonContainer container = new PersonContainer();
            container.People = new Person[]
            {
                new Person {Name = "John", Age = 19},
                new Person {Name = "Alice", Age = 21}
            };

            foreach (var p in container.GetAll(p => p.Age > 10))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
