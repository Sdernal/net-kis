using System;

namespace Factory
{
    class Car : IMovable
    {
        public string Name { get; }
        public int WheelsCount { get; }

        public Car(string name, int wheelsCount)
        {
            Name = name;
            WheelsCount = wheelsCount;
        }

        public virtual void Move()
        {
            Console.WriteLine($"Car \"{Name}\" with {WheelsCount} wheels moves");
        }
    }

    class Truck : Car
    {
        public int Capacity { get; }
        
        public Truck(string name, int wheelsCount, int capacity) : base(name, wheelsCount)
        {
            Capacity = capacity;
        }
        
        public override void Move()
        {
            Console.WriteLine($"Truck \"{Name}\" with {WheelsCount} wheels and {Capacity} kg capacity moves");
        }
    }
    
    class Plane : IMovable
    {
        public string Name { get; }
        public int WingsCount { get; }

        public Plane(string name, int wingsCount)
        {
            Name = name;
            WingsCount = wingsCount;
        }

        public virtual void Move()
        {
            Console.WriteLine($"Plane \"{Name}\" with {WingsCount} wings moves");
        }
    }
}