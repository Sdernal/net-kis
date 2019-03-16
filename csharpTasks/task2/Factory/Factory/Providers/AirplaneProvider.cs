using Factory.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public class AirplaneProvider : IProvider<Airplane>
    {
        public AirplaneProvider(int numberOfPassengers, int rangeOfFlight, string name)
        {
            NumberOfPassengers = numberOfPassengers;
            RangeOfFlight = rangeOfFlight;
            Name = name;
        }

        public Airplane CreateObject()
        {
            return new Airplane() { Name=this.Name, NumberOfPassengers = this.NumberOfPassengers,
                RangeOfFlight = this.RangeOfFlight};
        }

        public string Name { get; set; } = "unknown";
        public int NumberOfPassengers { get; set; } 
        public int RangeOfFlight { get; set; }
        
    }

    public static class AirplaneFactoryExtension
    {
        public static Airplane CreateAirplane(this Factory factory)
        {
            return factory.GetProvider<AirplaneProvider>()?.CreateObject();
        }
    }

    
}
