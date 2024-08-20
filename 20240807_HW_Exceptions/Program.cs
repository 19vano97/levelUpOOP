using _20240807_HW_Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        Equation e1 = new Equation(2, 3, -2);
        //double[] x = e1.X;

        e1.CalculateEquation();

        System.Console.WriteLine(e1);
        // e1[3] = 5;

        System.Console.WriteLine(e1.ToString());


        Equation e2 = new Equation(0, 4, 5);

        System.Console.WriteLine(e2.ToString());

        // Equation e3 = new Equation();
        // e3.A = 0;
    }
}