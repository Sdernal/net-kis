using System;
using System.Collections.Generic;
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
        
        public Person GetOne(Predicate<Person> pred)
        {
            foreach (var person in People)
            {
                if (pred(person))
                {
                    return person;
                }
            }
            return null;
        }

        public IEnumerable<Person> GetAll(Predicate<Person> pred)
        {
            foreach (var person in People)
            {
                if (pred(person))
                {
                    yield return person;
                }
            }
        }

        public bool Contains(Predicate<Person> pred)
        {
            foreach (var person in People)
            {
                if (pred(person))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
