using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class CarProvider: IFactoryProvider<Car>
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
        
        public Car CreateObject()
        {
            Car newCar = new Car(NumDoors);
            return newCar;
        }
    }
    class BMWProvider: IFactoryProvider<BMW>
    {
        private int Displacement;
        private string Type;
        public BMWProvider(int litres, string type)
        {
            Displacement = litres;
            Type = type;
        }
        public BMW CreateObject()
        {
            BMW newBMW = new BMW(Displacement, Type);
            return newBMW;
        }
    }
    class ZeppelinProvider : IFactoryProvider<Zeppelin>
    {
        private String ShellType;
        public ZeppelinProvider(string Type)
        {
            ShellType = Type;
        }
        public Zeppelin CreateObject()
        {
            Zeppelin newZeppelin = new Zeppelin(ShellType);
            return newZeppelin;
        }
    }
}
