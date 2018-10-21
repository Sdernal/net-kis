using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory {
    class TransportFactory {
        private CarProvider CarProvider_;
        private TruckProvider TruckProvider_;
        private AircraftProvider AircraftProvider_;

        public void AddProvider(TransportProvider Provider) {
            switch (Provider.GetType().Name) {
                case "CarProvider":
                    CarProvider_ = (CarProvider)Provider;
                    break;
                case "TruckProvider":
                    TruckProvider_ = (TruckProvider)Provider;
                    break;
                case "AircraftProvider":
                    AircraftProvider_ = (AircraftProvider)Provider;
                    break;
                default:
                    throw new Exception("Unknown provider");
            }
        }

        public TransportProvider GetProvider<T>() where T : TransportProvider {
            TransportProvider Provider = null;
            switch (typeof(T).Name) {
                case "CarProvider":
                    Provider = CarProvider_;
                    break;
                case "TruckProvider":
                    Provider = TruckProvider_;
                    break;
                case "AircraftProvider":
                    Provider = AircraftProvider_;
                    break;
                default:
                    throw new Exception("No such provider");
            }
            return Provider;
        }

        public void RemoveProvider<T>() where T : TransportProvider {
            switch (typeof(T).Name) {
                case "CarProvider":
                    CarProvider_ = null;
                    break;
                case "TruckProvider":
                    TruckProvider_ = null;
                    break;
                case "AircraftProvider":
                    AircraftProvider_ = null;
                    break;
                default:
                    throw new Exception("No such provider");
            }
        }
    }

    static class FactoryExtensions {
        public static Car CreateCar(this TransportFactory factory) {
            return (Car)factory.GetProvider<CarProvider>().CreateObject();
        }

        public static Truck CreateTruck(this TransportFactory factory) {
            return (Truck)factory.GetProvider<TruckProvider>().CreateObject();
        }

        public static Aircraft CreateAircraft(this TransportFactory factory) {
            return (Aircraft)factory.GetProvider<AircraftProvider>().CreateObject();
        }
    }
}
