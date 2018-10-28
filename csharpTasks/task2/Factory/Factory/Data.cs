using System;

namespace Factory
{
    class Car : IMovable
    {
        public Car(string name, uint passengerSeats, uint wheels)
        {
            Name = name;
            PassengerSeats = passengerSeats;
            Wheels = wheels;
        }

        public virtual void Move()
        {
            Console.WriteLine($"I'm {Name}. I have {Wheels} wheels and " +
                              $"{PassengerSeats} passenger seats.");
        }

        public string Name { get; protected set; }
        public uint PassengerSeats { get; protected set; }
        public uint Wheels { get; protected set; }
    }

    class Truck : Car
    {
        public Truck(string name, uint passengerSeats,
            uint wheels, uint maxWeight) : base(name, passengerSeats, wheels)
        {
            MaxWeight = maxWeight;
        }

        public override void Move()
        {
            Console.WriteLine($"I'm {Name}. I have {Wheels} wheels and " +
                              $"{PassengerSeats} passenger seats.");
            Console.WriteLine("Also, I can deliver " +
                              $"{MaxWeight} tones of items.");
        }

        public uint MaxWeight { get; protected set; }
    }

    class Plane : IMovable
    {
        public Plane(string name, uint wings,
            uint wheels, uint maxTakeoffWeight)
        {
            Name = name;
            Wings = wings;
            Wheels = wheels;
            MaxTakeoffWeight = maxTakeoffWeight;
        }

        public virtual void Move()
        {
            Console.WriteLine($"I'm {Name}. I have {Wings} wings and {Wheels}" +
                              $" wheels. My MTOW is {MaxTakeoffWeight} tones");
        }

        public string Name { get; protected set; }
        public uint Wings { get; protected set; }
        public uint Wheels { get; protected set; }
        public uint MaxTakeoffWeight { get; protected set; }
    }
}