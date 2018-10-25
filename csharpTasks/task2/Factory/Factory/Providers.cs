using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class Provider
    {
        public abstract Vehicle CreateObject();

        public abstract string GetProviderType();
    }
    class CarProvider: Provider
    {
        protected int NumDoors;
        public CarProvider()
        {
            NumDoors = 4;
        }
        public CarProvider(int num)
        {
            NumDoors = num;
        }

        public override string GetProviderType()
        {
            return "Car";
        }
        public override Vehicle CreateObject()
        {
            Car newCar = new Car(NumDoors);
            return newCar;
        }
    }
    class BMWProvider: CarProvider
    {
        private int Displacement;
        private string Type;
        public BMWProvider(int litres, string type)
        {
            Displacement = litres;
            Type = type;
        }
        public override string GetProviderType()
        {
            return "BMW";
        }
        public override Vehicle CreateObject()
        {
            BMW newBMW = new BMW(Displacement, Type);
            return newBMW;
        }
    }
    class ZeppelinProvider : Provider
    {
        private String ShellType;
        public ZeppelinProvider(string Type)
        {
            ShellType = Type;
        }
        public override string GetProviderType()
        {
            return "Zeppelin";
        }
        public override Vehicle CreateObject()
        {
            Zeppelin newZeppelin = new Zeppelin(ShellType);
            return newZeppelin;
        }

    }
}
