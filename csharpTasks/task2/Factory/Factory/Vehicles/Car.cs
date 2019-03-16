using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Vehicles
{
    public class Car : IMovable
    {
        public string Name { get; set; }

        public int NumberOfWheels { get; set; }

        public int NumberOfPassengers { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"Car(name: {Name}, number of wheels: {NumberOfWheels}, " +
                $"number of passengers: {NumberOfPassengers}) hashCode: {GetHashCode()}");
        }
    }
}
