using System;
using Xunit;
using DelegatesApp;
using System.Linq;

namespace DelegatesApp.Test
{
    public class PersonsTest
    {
        [Fact]
        public void GetAllTest()
        {
            PersonContainer container = new PersonContainer();
            container.People = GetTestPeople();
            var twenties = container.GetAll(p => p.Age > 20);
            // Console.WriteLine(twenties);
            // Assert.Equal(twenties.Current.Name,"Alice");
            Assert.Equal(2, twenties.Count());
        }

        [Fact]
        public void ContainsTest()
        {
            PersonContainer container = new PersonContainer();
            container.People = GetTestPeople();
            var contains = container.Contains(p => p.Age > 20);
            Assert.True(contains);
        }

        [Fact]
        public void GetBobTest()
        {
            PersonContainer container = new PersonContainer();
            container.People = GetTestPeople();
            var bob = container.GetOne(p => p.Name == "Bob");
            Assert.NotNull(bob);
            Assert.Equal("Bob", bob.Name);
        }

        private Person[] GetTestPeople()
        {
            return new Person[]
            {
                new Person {Name="John", Age=19},
                new Person {Name="Alice", Age=21},
                new Person {Name="Bob", Age=23}
            };
        }
    }
}
