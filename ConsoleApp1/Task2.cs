namespace P2;

public class Task2
{
    public void Run()
    {
        int arraySize;
        do
        { 
            arraySize = GetInt("\nNumber of participants: ");
        } while (arraySize <= 0);

        int[] arr = new int[arraySize];
        
        for (int i = 0; i < arr.Length; i++)
        {
            int answer;
            do
            {
            answer = GetInt($"Enter your {i + 1} answers (1 - Yes, 2 - No, 3 - Hard to say): ");
            } while (answer < 1 || answer > 3);
            arr[i] = answer;
        }

        int yes = 0;
        int no = 0;
        int undecided = 0;

        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] == 1)
                yes++;
            else if (arr[j] == 2)
                no++;
            else if  (arr[j] == 3)
                undecided++;
        }

        double agreePercent = (double)yes / arraySize * 100;
        double disagreePercent = (double)no / arraySize * 100;
        double undecidedPercent = (double)undecided / arraySize * 100;

        Console.WriteLine($"\n-----Results-----");
        Console.WriteLine($"Yes – {yes} votes({agreePercent:F1}%)");
        Console.WriteLine($"No – {no} votes({disagreePercent:F1}%)");
        Console.WriteLine($"Hard to say – {undecided} votes ({undecidedPercent:F1}%)");

        string winner;
        if (yes >= no && yes >= undecided)
        {
            winner = "Agree";
        }
        else if (no >= yes && no >= undecided)
        {
            winner = "Disagree";
        }
        else
        {
            winner = "Hard to say";
        }

        Console.WriteLine($"\nWinner: {winner}");
    }

    private static int GetInt(string text)
    {
        int result;
        do
        {
            Console.Write(text);
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}