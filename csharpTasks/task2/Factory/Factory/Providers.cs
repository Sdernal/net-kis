using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class TransportProvider {
        protected string Name_;

        protected TransportProvider(string Name) {
            Name_ = Name;
        }

        public abstract Transport CreateObject();
    }

    class CarProvider : TransportProvider{
        protected int Wheels_;

        public CarProvider(string Name = "Car", int Wheels = 4) : base(Name) {
            Wheels_ = Wheels;
        }

        public override Transport CreateObject() {
            return new Car(Name_, Wheels_);
        }
    }

    class TruckProvider : CarProvider {
        protected double Volume_;

        public TruckProvider(string Name = "Truck", int Wheels = 6, double Volume = 300) : base(Name, Wheels) {
            Volume_ = Volume;
        }

        public override Transport CreateObject() {
            return new Truck(Name_, Wheels_, Volume_);
        }
    }

    class AircraftProvider : TransportProvider {
        protected int Wings_;

        public AircraftProvider(string Name = "Aircraft", int Wings = 2) : base(Name) {
            Wings_ = Wings;
        }

        public override Transport CreateObject() {
            return new Aircraft(Name_, Wings_);
        }
    }
}
