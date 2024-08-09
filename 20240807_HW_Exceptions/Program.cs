using _20240807_HW_Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        Equation e1 = new Equation(2, 3, -2);

        System.Console.WriteLine(e1.ToString());


        Equation e2 = new Equation(3, 4, 5);

        System.Console.WriteLine(e2.ToString());

        
    }
}