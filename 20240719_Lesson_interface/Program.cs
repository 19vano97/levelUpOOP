using _20240719_Lesson_interface;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IConteiner c1 = null;

        Container1 c2 = new Container1();
    }

    public static void Print(IConteiner c)
    {
        if (c == null)
        {
            System.Console.WriteLine("Empty");
        }
        
        for (int i = 0; i < c.size; i++)
        {
            System.Console.WriteLine("{0}", c[i]);
        }
    }
}