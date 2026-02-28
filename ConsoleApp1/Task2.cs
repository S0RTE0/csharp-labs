namespace P1;

public class Task2
{
    public void Run()
    {
        int arraySize = GetInt("Number of participants: ");
        int[] arr = new int[arraySize];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = GetInt($"Enter your {i + 1} answers: ");
        }

        int agree = 0;
        int disagree = 0;
        int unsolicated = 0;

        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] == 1)
                agree++;
            else if (arr[j] == 2)
                disagree++;
            else
            {
                unsolicated++;
            }
        }
     
        
        
    }


    private static int GetInt(string text)
    {
        int result;
        do
        {
            Console.Write(text);
        } while (!int.TryParse (Console.ReadLine(), out result));

        return result;

    }
}