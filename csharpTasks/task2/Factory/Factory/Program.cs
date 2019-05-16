using System;

namespace Factory
{
    class Program
    {
        public static void Main(string[] args)
        {
            Factory universalFactory = new Factory();
            // Нужно уметь добавлять провайдеры
            universalFactory.AddProvider(new CarProvider("Toyota", "black", 5));
            // С помощью которых создавать нужные объекты
            Car car = universalFactory.CreateCar();
            car.Move(); // Просто выводит в консоль информацию о себе

            // Также можно задавать параметризованные провайдеры
            TruckProvider truckProvider = new TruckProvider("KAMAZ", "red", 2, 16);
            universalFactory.AddProvider(truckProvider);
            Truck truck = universalFactory.CreateTruck();
            truck.Move();
            // Грузовик это тоже машина
            Car car1 = universalFactory.CreateTruck();
            car1?.Move();
            //Нужно уметь явно запрашивать провайдер
            Car car2 = universalFactory.GetProvider<TruckProvider>().CreateObject();
            car2?.Move();
            universalFactory.DeleteProvider<CarProvider>();
            universalFactory.AddProvider(new PlaneProvider("AZ 357", "blue", 150, 2));
            universalFactory.CreatePlane().Move();
            universalFactory.GetProvider<PlaneProvider>().CreateObject().Move();

            // Насчет добавленных одинаковых провайдеров можно не беспокоиться, считаем, что один провайдер на тип
            // Можно явно проверять при добавлении или затирать старый
            // Также не помешает удаление провайдера для его последующей замены

            Console.ReadKey();
        }
    }
}
