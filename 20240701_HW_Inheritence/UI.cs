using System.Runtime.CompilerServices;

namespace _20240701_HW_Inheritence;

public class UI
{
    public static void DrawQuadrilateral(Point[] points, bool consoleClear = true)
    {
        if (consoleClear)
        {
            Console.Clear();
        }

        System.Console.WriteLine("File: {0}", points[0].PictureOwner.FileName);

        for (int i = 0; i < points.Length; i++)
        {
            Console.SetCursorPosition(points[i].CoordX, points[i].CoordY);
            System.Console.Write("P{0} ({1}, {2})", i, points[i].CoordX, points[i].CoordY);
            // System.Console.Write("#");
        }
    }

    public static void DrawSquare(Square squareToDraw, bool consoleClear = true)
    {
        if (consoleClear)
        {
            Console.Clear();
        }

        System.Console.WriteLine("File: {0}", squareToDraw.Points[0].PictureOwner.FileName);

        for (int i = 0; i < squareToDraw.Points.Length; i++)
        {
            Console.SetCursorPosition(squareToDraw.Points[i].CoordX, squareToDraw.Points[i].CoordY);
            System.Console.Write("P{0} ({1}, {2})", i, squareToDraw.Points[i].CoordX, squareToDraw.Points[i].CoordY);
            // System.Console.Write("#");
        }
    }

    public static void DrawCircle(Circle circleToDraw, bool consoleClear = true)
    {
        if (consoleClear)
        {
            Console.Clear();
        }

        Console.SetCursorPosition(0, 0);
        System.Console.WriteLine("File: {0}", circleToDraw.PictureOwner.FileName);

        for (int i = 0; i <= circleToDraw.Radius * 2; i++)
        {
            for (int k = 0; k <= circleToDraw.Radius * 2 * 2; k++)
            {
                int x = k - circleToDraw.Radius;
                int y = i - circleToDraw.Radius;
    
                if (x * x + y * y <= circleToDraw.Radius * circleToDraw.Radius)
                {
                    Console.SetCursorPosition(circleToDraw.Points[0].CoordX + x, circleToDraw.Points[0].CoordY + y);
                    System.Console.Write('#');
                }
            }
        }

        for (int i = 1; i < circleToDraw.Points.Length; i++)
        {
            Console.SetCursorPosition(circleToDraw.Points[i].CoordX, circleToDraw.Points[i].CoordY);
            System.Console.Write("P{0} ({1}, {2})", i, circleToDraw.Points[i].CoordX, circleToDraw.Points[i].CoordY);
            // System.Console.Write("#");
        }
    }

    public static void DrawCircleInSquare(CircleInSquare circleInSquareToDraw)
    {
        Console.Clear();

        DrawQuadrilateral(circleInSquareToDraw.Points);

        DrawCircle(circleInSquareToDraw.UseCircle, false);
    }
}
