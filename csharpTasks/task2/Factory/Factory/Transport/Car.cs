using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Transport
{
    public class Car: BaseVechile, IVechile
    {
        private Int64 CountWheels;
        public Car(int count_of_wheels = 4, string name = "Lada", Int64 fuel_cap = 100, double fuel_comp = 1) : base(name, fuel_cap, fuel_comp)
        {
            CountWheels = count_of_wheels;
        }

        public virtual void Move()
        {
            Console.WriteLine($"The Car: {Name} has {CountWheels} wheels and has FuelCapacity: {FuelCapacity} and has FuelConsumption: {FuelConsumption}");
        }
    }
}
