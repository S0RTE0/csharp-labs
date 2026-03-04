namespace P2;

public class Task4
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