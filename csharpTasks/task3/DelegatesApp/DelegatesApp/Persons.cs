﻿using System;
using System.Collections.Generic;
using System.Linq;

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
            return People.FirstOrDefault(predicate);
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> predicate)
        {
            return People.Where(predicate);
        }

        public bool Contains(Func<Person, bool> predicate)
        {
            return People.Any(predicate);
        }
    }
}
