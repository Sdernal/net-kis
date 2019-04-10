using Factory.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class PlaneProvider : IProvider<Plane>
    {
        private int number_;
        private string name_;
        private Int64 fuel_capacity_;
        private double fuel_consumption_;
        public PlaneProvider(int number = 2, string name = "Plane", Int64 capacity = 1000, double consump = 0.5)
        {
            number_ = number;
            name_ = name;
            fuel_capacity_ = capacity;
            fuel_consumption_ = consump;
        }

        public Plane CreateObject()
        {
            return new Plane(number_, name_, fuel_capacity_, fuel_consumption_);
        }
    }

    public static class PlaneFactoryExtension
    {
        public static Plane CreatePlane(this Factory factory)
        {
            return factory.GetProvider<PlaneProvider>()?.CreateObject();
        }
    }
}
