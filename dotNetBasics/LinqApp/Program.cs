using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    class Program
    {
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class Phone
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        static void Main(string[] args)
        {
            string[] countries = { "USA", "Russia", "Germany", "Georgia" };
            var startsG = from c in countries
                          where c.ToLower().StartsWith("g")
                          orderby c
                          select c;

            foreach(var s in startsG) Console.WriteLine(s);
           

            var notStartsG = countries.Where(c => !c.ToLower().StartsWith("g")).OrderBy(c => c);
            foreach (var s in notStartsG) Console.WriteLine(s);

            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            IEnumerable<int> evens = from i in numbers
                                     where i % 2 == 0 && i > 10
                                     select i;
            foreach (var i in evens) Console.WriteLine(i);
            
            evens = numbers.Where(i => i % 2 == 0 && i > 10);
            foreach (var i in evens) Console.WriteLine(i);

            var users = new User[]
            {
                new User {Name="Alice", Age=21},
                new User {Name="Bob", Age=21},
                new User {Name="John", Age=23 },
                new User {Name="Jack", Age=23}
            };

            var names = from u in users select u.Name;
            foreach (var name in names) Console.WriteLine(name);
            foreach (var age in users.Select(u => u.Age)) Console.WriteLine(age);

            var persons = from u in users
                          let name = u.Name + " Black"
                          select new
                          {
                              Name = name,
                              Age = u.Age + 5
                          };
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Name} : {p.Age}");
            }

            var phones = new Phone[] {
                new Phone {Name="IPhoneXs Max", Price=130000},
                new Phone {Name="Galaxy Note 9", Price=55000}
            };
            var pp = from u in users
                     from p in phones
                     select new { Name = u.Name, Phone = p.Name };
            foreach (var p in pp) Console.WriteLine($"{p.Name} - {p.Phone}");

            var sortedPhones = from p in phones
                               orderby p.Price
                               select p;
            foreach (var p in sortedPhones) Console.WriteLine($"{p.Name} - {p.Price}");
            sortedPhones = phones.OrderBy(p => p.Price);

            numbers = new int[] { 1,2,3,4,5, 6};
            var aggregated = numbers.Aggregate(0, (res,val) => val % 2 == 0 ? res + val : res);
            Console.WriteLine(aggregated);
            Console.WriteLine(phones.Sum(p => p.Price));

            numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach ( var n in numbers.Skip(3).Take(2))
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine();
            foreach (var n in numbers.SkipWhile(i => i < 2 ).TakeWhile(i => i < 6))
            {
                Console.Write($"{n} ");
            }

            var group = users.GroupBy(u => u.Age);
            group = from u in users
                    group u by u.Age;
            foreach (var g in group)
            {
                Console.WriteLine($"Age: {g.Key}");
                foreach(var u in g)
                {
                    Console.WriteLine($"Name: {u.Name}");
                }
                Console.WriteLine();
            }

            var selectedGroup = users.GroupBy(u => u.Age).Select(g => new { Name = g.Key, Count = g.Count() });
            selectedGroup = from user in users
                            group user by user.Age into g
                            select new { Name = g.Key, Count = g.Count() };
            foreach (var g in selectedGroup)
            {
                Console.WriteLine($"{g.Name} : {g.Count}");
            }

            JoinExample.Run();

            string[] english = { "Cat", "Dog", "Car" };
            string[] russian = { "Кошка", "Собака", "Машина" };
            var dict = english.Zip(russian,
                (e, r) => new { RU = r, EN = e });
            foreach( var item in dict)
            {
                Console.WriteLine($"{item.EN} - {item.RU}");
            }

            Console.WriteLine(english.Any(word => word.StartsWith("C")));
            Console.WriteLine(english.All(word => word.StartsWith("C")));
            Console.WriteLine(english.Contains("Cat"));
        }
    }
}
