using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        public static void Main(string[] args) {
            Factory universalFactory = new Factory();
            // Нужно уметь добавлять провайдеры
            universalFactory.AddProvider(new CarProvider());
            // С помощью которых создавать нужные объекты
            Car car = universalFactory.CreateCar();
            car.Move(); // Просто выводит в консоль информацию о себе

            // Также можно задавать параметризованные провайдеры
            //TruckProvider truckProvider = new TruckProvider(600, "BELAZ");
            TruckProvider truckProvider = new TruckProvider("BELAZ", "Lyoha", 600);
            universalFactory.AddProvider(truckProvider);
            Truck truck = universalFactory.CreateTruck();
            truck.Move();
            // Грузовик это тоже машина
            Car car1 = universalFactory.CreateTruck();
            car1?.Move();
            // Нужно уметь явно запрашивать провайдер
            Car car2 = universalFactory.GetProvider<TruckProvider>().CreateObject();
            car2?.Move();
            
            // Насчет добавленных одинаковых провайдеров можно не беспокоиться, считаем, что один провайдер на тип
            // Можно явно проверять при добавлении или затирать старый
            // Также не помешает удаление провайдера для его последующей замены
        }
    }
}
