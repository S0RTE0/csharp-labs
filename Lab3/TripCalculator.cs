namespace Lab3;

public class TripCalculator
{
    private static void Main(String[] args)
    {
        double fuel = GetDouble("Fuel: ");

        double distance = GetDouble("Distance: ");

        double price = GetDouble("Price: ");

        double speed = GetDouble("Speed: ");
        
        
        // ----------------------------------
        double totalFuel = CalculateFuelNeed(fuel, distance);

        double totalCost = CalculateTripCost(price, totalFuel);

        double totalTime = CalculateTravelTime(distance, speed);
        
        double miles = ConvertToMiles(distance);
        
        int totalHours = GetHours(totalTime);
        
        int totalMinutes = GetMinutes(totalTime);
        
        int stops = CalculateStops(totalTime);
        
        
        PrintTripSummary(distance, miles, totalHours, totalMinutes, stops, totalFuel, totalCost);
        
}

    private static double CalculateFuelNeed(double fuel, double distance)
    {
        return (fuel * distance) / 100;
    }

    private static double CalculateTripCost(double price, double totalFuelNeeded)
    {
        double cost = (price * totalFuelNeeded);
        return cost;
    } 

    private static double CalculateTravelTime(double distance, double speed)
    {
        return distance / speed;
    }

    private static int GetHours(double totalTime)
    {
        return (int)totalTime;
    }

    private static int GetMinutes(double totalTime)
    {
        return (int)((totalTime - (int)totalTime) * 60);
    }

    private static int CalculateStops(double totalTime)
    {
        return (int)(totalTime / 2.5);
    }

    private static double ConvertToMiles(double distance)
    {
        return distance * 0.621371;
    }

    private static void PrintTripSummary(double distance, double miles, int hours, int minutes, int stops, double totalFuel, double totalCost)
    {
        Console.WriteLine($"""
                           -----REPORT-----
                           Distance: {distance} ({miles:F2} miles)
                           {hours} hours,  {minutes} minutes
                           {stops} stops
                           {totalFuel:F2} fuel
                           {totalCost:F2} costs
                           """);
    }
    private static double GetDouble(string text)
    {
        double result;
        do
        {
            Console.Write(text);
        } while (!double.TryParse(Console.ReadLine(), out result));

        return result;
    }
}