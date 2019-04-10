using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Transport
{
    public class Plane: BaseVechile, IVechile
    {
        protected int NumberOfWings;

        public Plane(int number = 2, string name = "Plane", Int64 fuel_cap = 1000, double fuel_cons = 0.5): base(name, fuel_cap, fuel_cons)
        {
            NumberOfWings = number;
        }

        public void Move()
        {
            Console.WriteLine($"The Plane: {Name} has {NumberOfWings} number of wings " +
                $"and has FuelCapacity: {FuelCapacity} and has FuelConsumption: {FuelConsumption}");
        }
    }
}
