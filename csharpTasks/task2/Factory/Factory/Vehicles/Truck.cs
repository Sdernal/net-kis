using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Vehicles
{
    public class Truck : Car, IMovable
    {
        public int Capacity { get; set; }

        public override void Move()
        {
            Console.WriteLine($"Truck(name: {Name}, number of wheels: {NumberOfWheels}, " +
                $"number of passengers: {NumberOfPassengers}, capacity: {Capacity}) hashCode: {GetHashCode()}");
        }
    }
}
