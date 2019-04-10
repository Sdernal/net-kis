using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Transport
{
    public class BaseVechile
    {
        protected string Name;
        protected Int64 FuelCapacity;
        protected double FuelConsumption;

        public BaseVechile(string name, Int64 fuel_cap, double fuel_cons)
        {
            Name = name;
            FuelCapacity = fuel_cap;
            FuelConsumption = fuel_cons;
        }
    }
}
