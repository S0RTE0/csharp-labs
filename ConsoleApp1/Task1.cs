using  System.Linq;

namespace P2;

public class Task1
{
    public void Run()
    {
        int arraySize = getInt("Enter your size: ");
        int[] arr = new int[arraySize];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = getInt($"Enter your {i + 1} numbers: ");    
        }



        Console.Write($"""
                       Array: {string.Join(",", arr)}
                       Max number:  {arr.Max()}
                       Min number: {arr.Min()}
                       Average:  {arr.Average()}
                       Sum:  {arr.Sum()}
                       """);
    }

    private static int getInt(string text)
    {
        int result;
        do
        {
            Console.Write(text);
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;

    }
}