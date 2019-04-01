using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesApp
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Имя: {Name} Возраст: {Age}";
        }
    }

    // Тут нужно реализовать методы-заглушки
    // О том, какие аргументы нужно использовать в методах подумайте сами
    public class PersonContainer
    {
        public Person[] People { get; set; }
        
        public Person GetOne(Predicate<Person> predicate)
        {
            foreach (var people in People)
            {
                if (predicate(people))
                {
                    return people;
                }
            }
            return null;
        }

        public IEnumerable<Person> GetAll(Predicate<Person> predicate)
        {
            foreach (var people in People)
            {
                if (predicate(people))
                {
                    yield return people;
                }
            }
        }

        public bool Contains(Predicate<Person> predicate)
        {
            foreach (var people in People)
            {
                if (predicate(people)) return true;
            }
            return false;
        }
    }
}
