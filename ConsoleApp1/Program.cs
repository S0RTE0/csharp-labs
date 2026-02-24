using System.Globalization;

namespace P1
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            int answer;
            do
            {
                Console.Write("Task: ");
                answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        T1();
                        break;
                    case 2:
                        T2();
                        break;
                    case 3:
                        T3();
                        break;
                }
            } while (answer != 0);
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

        private static void T1()
        {
            Console.Write("Enter your product: ");
            string product = Console.ReadLine();
            
            int price =  getInt("Enter your price: ");

            int quantity = getInt("Enter quantity: ");

            int total =  price * quantity;
            float tax = total * 0.2f;
            int totalWithTax =  (int) MathF.Round(total + tax);

            string text = $"""
                           ----- CHECK -----
                           Product: {product}
                           Quantity: {quantity}
                           Price per item: {price}
                           Total price: {total}
                           Tax(20%): {tax}
                           Total with tax: {totalWithTax}
                           ------------------
                           """;
            Console.WriteLine(text);
        }

        
        
        
        private static void T2()
        {
            int length = getInt("Enter your amount of grades: ");
            int[] grades = new int[length];
            for (int i = 0; i < length; i++)
            {
                grades[i] = getInt($"Grade {i + 1}: ");
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{grades[i]} ");
            }
            Console.Write("\n");
            float avg = AVG(grades, length);
            int goodGrades = perfectGrade(grades, length);
            int badGrades = badGrade(grades, length);
            string rating = Rating(avg);
            string text = $"""
                           ----- GRADES -----
                           Average: {avg}
                           Perfect grades: {goodGrades}
                           Bad grades: {badGrades}
                           Your rating: {rating}
                           ------------------
                           """;
            Console.WriteLine(text);

            float AVG(int[] arr, int len)
            {
                int sum = 0;
                for (int i = 0; i < len; i++)
                {
                    sum += arr[i];
                }
                float avg = MathF.Round(sum / (float)len, 2);
                return avg;
            }

            int perfectGrade(int[] arr, int len)
            {
                int goodGrades = 0;
                for (int i = 0; i < len; i++)
                {
                    if (arr[i] >= 90)
                    {
                        goodGrades++;
                    }
                }
                return goodGrades;
            }

            int badGrade(int[] arr, int len)
            {
                int badGrades = 0;
                for (int i = 0; i < len; i++)
                {
                    if (arr[i] < 60)
                    {
                        badGrades++;
                    }
                }
                return badGrades;
            }
            
            string Rating(float avg)
            {
                if (avg < 35)
                {
                    return "Bad";
                }

                if (avg < 50 && avg > 35)
                {
                    return "Average";
                }

                if (avg < 85 && avg > 50)
                {
                    return "Good";
                }

                if (avg > 85)
                {
                    return "Excellent";
                }
                else
                {
                    return "Error. Try again";
                }
            }
        }




        private static void T3()
        {
            int firstNum;
            int secondNum;
            
            int choice;
            do
            {
                firstNum = getInt("First number: ");
                secondNum = getInt("Second number: ");
                string menu = """
                              [0] - Exit
                              [1] - Add
                              [2] - Sub
                              [3] - Mult
                              [4] - Div
                              """;

                Console.WriteLine(menu);
                
                choice = getInt("Choose an option: ");

                switch (choice)
                {
                    case 1:
                    {
                        int result = add(firstNum, secondNum);
                        Console.WriteLine(result);
                        break;
                    }
                    case 2:
                    {
                        int result = sub(firstNum, secondNum);
                        Console.WriteLine(result);
                        break;
                    }
                    case 3:
                    {
                        int result = mult(firstNum, secondNum);
                        Console.WriteLine(result);
                        break;
                    }
                    case 4:
                    {
                        int result = div(firstNum, secondNum);
                        Console.WriteLine(result);
                        break;
                    }
                }
            } while (choice != 0);

            int add(int fnum, int snum)
            {
                return fnum + snum;
            }
            int sub(int fnum, int snum)
                {
                return fnum - snum;
                }
            int mult(int fnum, int snum)
            {
                return fnum * snum;
            }
            int div(int fnum, int snum)
            {
                return fnum / snum;
            }
        }
    }
}




