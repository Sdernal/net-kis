using System;
using System.Collections.Generic;

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

        public Person GetOne(Func<Person, bool> predicate)
        {
            foreach (var person in People)
            {
                if (predicate(person))
                {
                    return person;
                }
            }

            return null;
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> predicate)
        {
            var result = new List<Person>();
            foreach (var person in People)
            {
                if (predicate(person))
                {
                    result.Add(person);
                }
            }

            return result;
        }

        public bool Contains(Func<Person, bool> predicate)
        {
            foreach (var person in People)
            {
                if (predicate(person))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
