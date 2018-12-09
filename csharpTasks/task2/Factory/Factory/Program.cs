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
            BMWProvider truckProvider = new BMWProvider(4, "X5");
            universalFactory.AddProvider(truckProvider);
            BMW truck = universalFactory.CreateBMW();
            truck.Move();
            // Грузовик это тоже машина
            Car car1 = universalFactory.CreateBMW();
            car1?.Move();
            //Нужно уметь явно запрашивать провайдер
            Car car2 = universalFactory.GetProvider<BMWProvider>().CreateObject();
            car2?.Move();

            // Насчет добавленных одинаковых провайдеров можно не беспокоиться, считаем, что один провайдер на тип
            // Можно явно проверять при добавлении или затирать старый
            // Также не помешает удаление провайдера для его последующей замены

            Console.ReadKey();
        }
    }
}
