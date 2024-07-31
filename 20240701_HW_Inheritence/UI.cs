using System.Runtime.CompilerServices;

namespace _20240701_HW_Inheritence;

public class UI
{
    public static void DrawSquare(Square squareToDraw, bool consoleClear = true)
    {
        if (consoleClear)
        {
            Console.Clear();
        }

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

        int size = circleToDraw.GetView().Length;

        for (int i = 0; i < size; i++)
        {
            Console.SetCursorPosition(circleToDraw.GetView()[i].x, circleToDraw.GetView()[i].y);
            // System.Console.Write("P{0} ({1}, {2})", i, circleToDraw.GetView()[i].X, circleToDraw.GetView()[i].Y);
            System.Console.Write('#');
        }
    }

    public static void DrawPicture(Picture pictureToDraw)
    {
        Console.Clear();

        int size = pictureToDraw.GetView().Length;

        for (int i = 0; i < size; i++)
        {
            int x = pictureToDraw.GetView()[i].x;
            int y = pictureToDraw.GetView()[i].y;

            Console.SetCursorPosition(x, y);

            System.Console.Write(pictureToDraw.GetView()[i].symdol);
        }
 
    }

    public static void PrintIGeometrical(IGeometrical ig)
    {
        System.Console.WriteLine("Area: {0}", ig.GetArea());
        System.Console.WriteLine("Perimeter: {0}", ig.GetPerimeter());
    }

    public static void PrintArrayOfPerimetersInPic(Picture pic)
    {
        // for (int i = 0; i < pic.Points.Length; i++)
        // {
        //     IGeometrical ig = pic.Points[i] as IGeometrical;

        //     System.Console.WriteLine("Perimeter {0}: {1}", ig, ig.GetPerimeter());
        // }

        foreach (var item in pic)
        {
            IGeometrical ig = item as IGeometrical;

            System.Console.WriteLine("Perimeter {0}: {1}", ig, ig.GetPerimeter());
        }
    }

    public static void PrintArrayOfAreaInPic(Picture pic)
    {
        // for (int i = 0; i < pic.Points.Length; i++)
        // {
        //     IGeometrical ig = pic.Points[i] as IGeometrical;

        //     System.Console.WriteLine("Area {0}: {1}", ig, ig.GetArea());
        // }

        foreach (var item in pic)
        {
            IGeometrical ig = item as IGeometrical;

            System.Console.WriteLine("Area {0}: {1}", ig, ig.GetArea());
        }
    }
}
