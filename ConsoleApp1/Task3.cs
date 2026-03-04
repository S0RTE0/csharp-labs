namespace P2;

public class Task3
{
    public void Run()
    {
        const int length = 10;
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = getInt("Enter your array: ");
        }

        Console.WriteLine("Original array: " + string.Join(", ", array));

        ReverseArray(array);
        GreaterThanNum(array);
        FindFirstZeroIndex(array);
        CheckDuplicates(array);
    }

    private void ReverseArray(int[] arr)
    {
        Console.Write("Reversed array: ");
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + ", ");
        }

        Console.WriteLine();
    }

    private void GreaterThanNum(int[] arr)
    {
        int count = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                count++;
            }
        }

        Console.WriteLine($"Bigger nums: {count}");
    }

    private void FindFirstZeroIndex(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                Console.WriteLine($"First zero index: {i}");
                break;
            }
        }
    }

    private void CheckDuplicates(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                Console.WriteLine($"Duplicates: {i}");
            }
        }
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