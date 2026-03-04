namespace P2;

public class Task4
{
    Random rnd = new Random();
    public void Run()
    {
        int rows = rnd.Next(2, 10);
        int col = rnd.Next(2, 10);
        int[,] matrix = new int [rows, col];
        matrix = CreateMatrix(matrix, rows, col);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.Write("\n");
        }

        int takenSeats = Taken(matrix, rows, col);
        Console.WriteLine($"Taken seats: {takenSeats}");
        
        int rowWithMostSeats = MostSeatsTaken(matrix, rows, col);
        Console.WriteLine($"Most seats taken on row: {rowWithMostSeats + 1}");
    }

    private int MostSeatsTaken(int[,] matrix, int rows, int col)
    {
        int[] rowsSum = new int[rows];
        for (int i = 0;  i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i, j] == 1)
                {
                    rowsSum[i]++;
                }
            }
        }
        return Array.IndexOf(rowsSum, rowsSum.Max());
    }
    
    private int Taken(int[,] matrix, int rows, int col)
    {
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i, j] == 1)
                {
                    counter++;
                }
            }
        }

        return counter;
    }
    
    private int[,] CreateMatrix(int[,] matrix, int rows, int col)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = rnd.Next(0, 2);
            }
        }

        return matrix;
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