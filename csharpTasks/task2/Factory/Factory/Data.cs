using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class Vehicle: IMovable
    {
        public abstract void Move();
    }

    class Car: Vehicle
    {
        protected int NumDoors;
        public Car()
        {
            NumDoors = 4;
        }
        public Car(int num)
        {
            NumDoors = num;
        }
        public override void Move()
        {
            Console.WriteLine("This is the car!");
        }
    }
    class BMW: Car
    {
        private int Displacement;
        private string Type;
        public BMW(int NumLitres, String TypeBMW)
        {
            Displacement = NumLitres;
            Type = TypeBMW;
        }
        public override void Move()
        {
            Console.WriteLine($"This is the BMW {Type} with displacement {Displacement} litres!");
        }
    }
    class Zeppelin: Vehicle
    {
        private String ShellType;
        public Zeppelin(string Type)
        {
            ShellType = Type;
        }
        public override void Move()
        {
            Console.WriteLine($"This is the Zeppelin with {ShellType} type of shell!");
        }

    }
}
