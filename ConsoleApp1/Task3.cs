namespace P1;

public class Task3
{
    public void Run()
    {
        
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