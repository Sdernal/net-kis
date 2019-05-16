using System;

namespace Factory
{
    class Car : IMovable
    {
        public string Brend { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }

        public Car(string brend, string color, int seats)
        {
            Brend = brend;
            Color = color;
            Seats = seats;
        }

        public virtual void Move()
        {
            Console.WriteLine($"Car {Brend}, painted {Color} with {Seats} seats");
        }
    }
    class Truck : Car
    {
        public int Wheels { get; set; }
        public Truck(string brend, string color, int seats, int wheels) : base(brend, color, seats)
        {
            Wheels = wheels;
        }

        public override void Move()
        {
            Console.WriteLine($"Car {Brend}, painted {Color} with {Seats} seats and {Wheels} wheels");
        }
    }
    class Plane : IMovable
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public int Wings { get; set; }

        public Plane(string model, string color, int seats, int wings)
        {
            Model = model;
            Color = color;
            Seats = seats;
            Wings = wings;
        }

        public virtual void Move()
        {
            Console.WriteLine($"Plane {Model}, painted {Color} with {Seats} seats and {Wings} wings");
        }
    }
}