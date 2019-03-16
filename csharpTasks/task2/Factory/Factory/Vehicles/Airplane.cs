using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Vehicles
{
    public class Airplane : IMovable
    {
        public int NumberOfPassengers { get; set; }

        public string Name { get; set; }

        public int RangeOfFlight { get; set; }

        public void Move()
        {
            Console.WriteLine($"Airplane(name: {Name}, number of passengers: {NumberOfPassengers}) " +
                $"hashCode: {GetHashCode()}");
        }
    }
}
