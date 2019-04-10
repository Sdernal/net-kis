using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Transport
{
    public class Truck: Car, IVechile
    {
        private double Weight;
        public Truck(double weight = 1000, string name="truck", Int64 capacity = 1000, double consump = 0.5) : base(4, name, capacity, consump)
        {
            Weight = weight;
        }

        public override void Move()
        {
            Console.WriteLine($"The Track: {Name} is weighted {Weight} and has FuelCapacity: {FuelCapacity} and has FuelConsumption: {FuelConsumption}");
        }
 
    }
}
