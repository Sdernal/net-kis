

using System;

namespace Factory
{
    public abstract class Transport : IMovable
    {
        public string Name {get;}


        public Transport (string newName)
        {
            Name = newName;
        }
        public abstract void Move();
    }

    public class Car : Transport
    {
        string DriverName {get;}

        public Car (string newName, string newDriverName) : base(newName) 
        {
            DriverName = newDriverName;
        }
        public override void Move()
        {
            Console.WriteLine("Beep, beep! It's the car ${Name}. ${DriverName} is racing towards adventures!");
        }
    }

    public class Truck : Car
    {
        double Capacity {get;}

        public Truck (string newName, string newDriverName, double newCapacity) : base(newName, newDriverName)
        {
            this.Capacity = newCapacity;
        }

        public override void Move()
        {
            Console.WriteLine("Beep, beep! It's the truck ${Name}. ${DriverName} is racing towards unloading ${Capacity} kg");
        }
    }

    public class Airplane : Transport
    {
        double WingsLength {get;}

        public Airplane(string newName, double newWingsLength) : base(newName)
        {
            this.WingsLength = newWingsLength;
        }
        
        public override void Move()
        {
            Console.WriteLine("Wow, Wow! It's the aircraft ${Name}. ${DriverName} is flying towards with its ${WingsLegnth} ");
        }
    }
}