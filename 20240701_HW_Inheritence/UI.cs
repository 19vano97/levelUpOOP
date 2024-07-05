namespace _20240701_HW_Inheritence;

public class UI
{
    public static void DrawQuadrilateral(Point[] points)
    {
        Console.Clear();

        for (int i = 0; i < points.Length; i++)
        {
            Console.SetCursorPosition(points[i].CoordX, points[i].CoordY);
            // System.Console.Write("P{0} ({1}, {2})", i, points[i].CoordX, points[i].CoordY);
            System.Console.Write("#");
        }
    }
}
