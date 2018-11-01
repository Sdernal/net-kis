using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DelegatesApp
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Person(Name: {Name}, Age: {Age});";
        }
    }

    // Тут нужно реализовать методы-заглушки
    // О том, какие аргументы нужно использовать в методах подумайте сами
    public class PersonContainer
    {
        public Person[] People { get; set; }

        public Person GetOne(Func<Person, bool> filter) {
            try {
                return People.Single(filter);
            }
            catch (InvalidOperationException) {
                return null;
            }
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> filter)
        {
            try {
                return People.Where(filter);
            }
            catch (InvalidOperationException) {
                return null;
            }
        }

        public bool Contains(Func<Person, bool> filter)
        {
            return People.Any(filter);
        }
    }
}
