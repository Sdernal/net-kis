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
            RandomPearson randomPerson = new RandomPearson();
            market.AddSubscriber(broker);
            market.AddSubscriber(randomPerson);

            Console.WriteLine(broker);
            Console.WriteLine(randomPerson);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Trade #{i + 1}\n");
                market.Trade();
                Console.WriteLine(broker);
                Console.WriteLine(randomPerson);
            }

//            PersonContainer container = new PersonContainer();
//            container.People = new Person[]
//            {
//                new Person {Name="John", Age=19},
//                new Person {Name="Alice", Age=21}
//            };
//
//            foreach (var p in container.GetAll(p => p.Age > 10))
//            {
//                Console.WriteLine(p.ToString());
//            }
        }
    }
}
