using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Car: IMovable
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
        public virtual void Move()
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
    class Zeppelin: IMovable
    {
        private String ShellType;
        public Zeppelin(string Type)
        {
            ShellType = Type;
        }
        public virtual void Move()
        {
            Console.WriteLine($"This is the Zeppelin with {ShellType} type of shell!");
        }

    }
}
