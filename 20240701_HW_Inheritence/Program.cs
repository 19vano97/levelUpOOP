using _20240701_HW_Inheritence;

internal class Program
{
    private static void Main(string[] args)
    {
        Quadrilateral newQuadrilateral = new Quadrilateral(12, 2, 4);

        Square newSquare = new Square(newQuadrilateral);

        UI.DrawQuadrilateral(newSquare.Points);
        Console.ReadKey();

        Rectangle newRectangle = new Rectangle(newQuadrilateral, 3);
        UI.DrawQuadrilateral(newRectangle.Points);

        Console.ReadKey();

        newSquare.Rotate45(newSquare.Points);
        UI.DrawQuadrilateral(newSquare.Points);

        Console.ReadKey();

        newSquare.Resize(newSquare.Points, 5);
        UI.DrawQuadrilateral(newSquare.Points);

        Console.ReadKey();

        

        newRectangle.Resize(newRectangle.Points, 2);
        UI.DrawQuadrilateral(newRectangle.Points);

        Console.ReadKey();

        newRectangle.Rotate45(newRectangle.Points);
        UI.DrawQuadrilateral(newRectangle.Points);

        Console.ReadKey();
    }
}