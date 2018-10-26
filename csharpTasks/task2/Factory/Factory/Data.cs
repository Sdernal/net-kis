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

        protected string Name;
        protected uint PassengerSeats;
        protected uint Wheels;
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

        protected uint MaxWeight;
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

        protected string Name;
        protected uint Wings;
        protected uint Wheels;
        protected uint MaxTakeoffWeight;
    }
}