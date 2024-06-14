using System.Drawing;

namespace _20240610_Lesson22;

internal class Program
{
    private static void Main(string[] args)
    {
        NewPoint p0 = new NewPoint();

        p0.Color = ConsoleColor.DarkYellow;

        ConsoleColor c = p0.Color;

        BL.Move(ref p0, 5, 7);

        p0.Move(5, -2);

        NewPoint p1 = new NewPoint(12, 4);

        int x1 = p1.GetX();
        int y1 = p1.GetY();

        int x0 = p0.GetX();
        int y0 = p0.GetY();

        if (p0.GetError() != ErrorState.Success)
        {
            System.Console.WriteLine("Wrong");
        }

        p0.SetY(10);
        p0.SetX(-10);
    }
}