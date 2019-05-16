namespace Factory
{
    class CarProvider : IFactoryProvider<Car>
    {
        public string Brend { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }

        public CarProvider(string brend, string color, int seats)
        {
            Brend = brend;
            Color = color;
            Seats = seats;
        }

        public Car CreateObject()
        {
            return new Car(Brend, Color, Seats);
        }
    }
    class TruckProvider : IFactoryProvider<Truck>
    {
        public string Brend { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public int Wheels { get; set; }

        public TruckProvider(string brend, string color, int seats, int wheels)
        {
            Brend = brend;
            Color = color;
            Seats = seats;
            Wheels = wheels;
        }

        public Truck CreateObject()
        {
            return new Truck(Brend, Color, Seats, Wheels);
        }
    }
    class PlaneProvider : IFactoryProvider<Plane>
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public int Wings { get; set; }

        public PlaneProvider(string model, string color, int seats, int wings)
        {
            Model = model;
            Color = color;
            Seats = seats;
            Wings = wings;
        }

        public Plane CreateObject()
        {
            return new Plane(Model, Color, Seats, Wings);
        }
    }
    static class FactoryExtensions
    {
        public static Car CreateCar(this Factory F)
        {
            return F.GetProvider<CarProvider>()?.CreateObject();
        }
        public static Truck CreateTruck(this Factory F)
        {
            return F.GetProvider<TruckProvider>()?.CreateObject();
        }
        public static Plane CreatePlane(this Factory F)
        {
            return F.GetProvider<PlaneProvider>()?.CreateObject();
        }
    }
}