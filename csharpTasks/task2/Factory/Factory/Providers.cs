namespace Factory
{
    class CarProvider : IProvider<Car>
    {
        private string name_;
        private string driverName_;
        public CarProvider(string name = "Volvo", string driverName = "Ilyuha")
        {
            name_ = name;
            driverName_ = driverName;
        }
        public Car CreateObject()
        {
            return new Car(name_, driverName_);
        }
    }
    
    public static class CarFactoryExtension
    {
        public static Car CreateCar(this Factory factory)
        {
            return factory.GetProvider<CarProvider>()?.CreateObject();
        }
    }

    class TruckProvider : IProvider<Truck>
    {
        private string name_;
        private string driverName_;
        private double capacity_;

        public TruckProvider(string name = "Belaz", string driverName = "Lyoha", double capacity = 20)
        {
            name_ = name;
            driverName_ = driverName;
            capacity_ = capacity;
        }
        public Truck CreateObject()
        {
            return new Truck(name_, driverName_, capacity_);
        }
    }
    
    public static class TruckFactoryExtension
    {
        public static Truck CreateTruck(this Factory factory)
        {
            return factory.GetProvider<TruckProvider>()?.CreateObject();
        }
    }

    class AirplaneProvider : IProvider<Airplane>
    {
        private string name_;
        private double wingsLength_;

        public AirplaneProvider(string name = "Sukhoy", double wingsLength = 10.5)
        {
            name_ = name;
            wingsLength_ = wingsLength;
        }
        public Airplane CreateObject()
        {
            return new Airplane(name_, wingsLength_);
        }
    }
    
    public static class AirplaneFactoryExtension
    {
        public static Airplane CreateAirplane(this Factory factory)
        {
            return factory.GetProvider<AirplaneProvider>()?.CreateObject();
        }
    }
}