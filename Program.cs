namespace Program
{
    public class Engine
    {
        public int Power { get; set; }
        public string FuelType { get; set; }

        public Engine(int power, string fuelType)
        {
            Power = power;
            FuelType = fuelType;
        }

        public string GetEngineSpecs()
        {
            return $"{Power} HP, {FuelType}";
        }
    }

    public class GPSNavigator
    {
        public string Model { get; set; }
        public string InstalledMaps { get; set; }

        public GPSNavigator(string model, string installedMaps)
        {
            Model = model;
            InstalledMaps = installedMaps;
        }

        public string GetStatus()
        {
            return $"GPS '{Model}' is working. Installed maps: {InstalledMaps}.";
        }
    }

    public class Driver
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }

        public Driver(string name, int experienceYears)
        {
            Name = name;
            ExperienceYears = experienceYears;
        }
    }

    public class Car
    {
        private Engine _engine;

        public GPSNavigator Navigator { get; set; }
        public Driver CarDriver { get; set; }

        public Car(int enginePower, string fuelType)
        {
            _engine = new Engine(enginePower, fuelType);
        }

        public void Drive()
        {
            if (CarDriver != null)
            {
                Console.WriteLine($"[ACTION] The car has started moving. Driver: {CarDriver.Name}.");
            }
            else
            {
                Console.WriteLine($"[ERROR] Cannot start moving. The car needs a driver!");
            }
        }

        public void GetFullCarInfo()
        {
            Console.WriteLine("\n--- Full Car Specification ---");
            
            Console.WriteLine($"Engine: {_engine.GetEngineSpecs()}");

            if (Navigator != null)
                Console.WriteLine($"Navigator: {Navigator.GetStatus()}");
            else
                Console.WriteLine("Navigator: Not installed.");

            if (CarDriver != null)
                Console.WriteLine($"Driver: {CarDriver.Name} ({CarDriver.ExperienceYears} years of experience)");
            else
                Console.WriteLine("Driver: No driver currently assigned.");
            
            Console.WriteLine("------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(450, "Petrol");

            Driver firstDriver = new Driver("Mark", 5);
            GPSNavigator garminNav = new GPSNavigator("Garmin 1000", "Europe & UK");

            myCar.CarDriver = firstDriver;
            myCar.Navigator = garminNav;

            myCar.GetFullCarInfo();
            myCar.Drive();

            Console.WriteLine("\n*** SWAPPING DRIVER AND NAVIGATOR ***");

            Driver secondDriver = new Driver("Vovp", 12);
            GPSNavigator tomtomNav = new GPSNavigator("TomTom GO", "Worldwide");

            myCar.CarDriver = secondDriver;
            myCar.Navigator = tomtomNav;


            myCar.GetFullCarInfo();
            myCar.Drive();
            

        }
    }
}