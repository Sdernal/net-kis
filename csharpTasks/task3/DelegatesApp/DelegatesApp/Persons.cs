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
        
        public Person GetOne(Func<Person, bool> f)
        {
            foreach (Person person in People)
            {
                if (f(person))
                {
                    return person;
                }
            }
            return null;
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> f)
        {
            foreach (Person person in People)
            {
                if (f(person))
                {
                    yield return person;
                }
            }
        }

        public bool Contains(Func<Person, bool> f)
        {
            foreach (Person person in People)
            {
                if (f(person))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
