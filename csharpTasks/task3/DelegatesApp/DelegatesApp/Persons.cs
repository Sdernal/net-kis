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
        
        public Person GetOne(Predicate<Person> predicate)
        {
            foreach (var p in People) {
                if (predicate(p)) {
                    return p;
                }
            }
            return null;
        }

        public IEnumerable<Person> GetAll()
        {
            foreach (var p in People) {
                if (predicate(p)) {
                    yield return p;
                }
            }
        }

        public bool Contains()
        {
            foreach (var p in People) {
                if (predicate(p)) {
                    return true;
                }
            }
            return false;
        }
    }
}
