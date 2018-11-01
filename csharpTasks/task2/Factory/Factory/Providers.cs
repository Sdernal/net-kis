using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class CarProvider : IFactoryProvider<Car> {
        protected string name_;
        protected int wheels_;

        public CarProvider(string Name = "Car", int Wheels = 4) {
            name_ = Name;
            wheels_ = Wheels;
        }

        public Car CreateObject() {
            return new Car(name_, wheels_);
        }
    }

    static class CarProviderFactoryExtension {
        public static Car CreateCar(this TransportFactory factory) {
            return factory.GetProvider<CarProvider>().CreateObject();
        }
    }

    class TruckProvider : IFactoryProvider<Truck> {
        protected string name_;
        protected int wheels_;
        protected double volume_;

        public TruckProvider(string Name = "Truck", int Wheels = 6, double Volume = 300) {
            name_ = Name;
            wheels_ = Wheels;
            volume_ = Volume;
        }

        public Truck CreateObject() {
            return new Truck(name_, wheels_, volume_);
        }
    }

    static class TruckProviderFactoryExtension {
        public static Truck CreateTruck(this TransportFactory factory) {
            return factory.GetProvider<TruckProvider>().CreateObject();
        }
    }

    class AircraftProvider : IFactoryProvider<Aircraft> {
        protected string name_;
        protected int wings_;

        public AircraftProvider(string Name = "Aircraft", int Wings = 2) {
            name_ = Name;
            wings_ = Wings;
        }

        public Aircraft CreateObject() {
            return new Aircraft(name_, wings_);
        }
    }

    static class AircraftProviderFactoryExtension {
        public static Aircraft CreateAircraft(this TransportFactory factory) {
            return factory.GetProvider<AircraftProvider>().CreateObject();
        }
    }
}
