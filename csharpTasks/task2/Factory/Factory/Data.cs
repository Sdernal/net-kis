using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory {
    abstract class Transport : IMovable {
        public readonly string Name_;

        protected Transport(string Name) {
            Name_ = Name;
        }

        public abstract void Move();
    }

    class Car : Transport {
        public readonly int Wheels_;

        public Car(string Name, int Wheels) : base(Name) {
            Wheels_ = Wheels;
        }

        public override void Move() {
            Console.WriteLine($"Car '{Name_}' is riding on it's {Wheels_} wheels");
        }
    }

    class Truck : Car {
        public readonly double Volume_;

        public Truck(string Name, int Wheels, double Volume) : base(Name, Wheels) {
            Volume_ = Volume;
        }

        public override void Move() {
            Console.WriteLine($"Truck '{Name_}' of volume {Volume_} is riding on it's {Wheels_} wheels");
        }
    }

    class Aircraft : Transport {
        public readonly int Wings_;

        public Aircraft(string Name, int Wings) : base(Name) {
            Wings_ = Wings;
        }

        public override void Move() {
            Console.WriteLine($"Aircraft '{Name_}' is flying on it's {Wings_} wings");
        }
    }
}
