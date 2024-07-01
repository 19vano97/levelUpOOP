using System;

using _20240610_IncapsulationDemo;

namespace _20240509_StructsDemo
{
    public class UI
    {
        // p - by value !!!
        public static void Show(Point p)
        {
            //Console.ForegroundColor = p.Color;

            Show(p.X, p.Y);
            //Show(p.GetX(), p.GetY());

            // copy!!!
            p.X += 2;
            //p.SetX(p.GetX()+2);
            //p.Y += 3;
        }

        public static void Show(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write($"({x}, {y})");
            Console.Write("*");
        }

        public static void Hide(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write($"({x}, {y})");
            Console.Write(" ");

        }

        //public static void ShowPolyLine(Point[] coords)
        //{
        //    for (int i = 0; i < coords.Length; i++)
        //    {
        //        Show(coords[i]);
        //        if (i < coords.Length - 1)
        //        {
        //            Console.Write("-");
        //        }
        //    }
        //    Console.WriteLine();
        //}

        public static Point InputPoint()
        {
            int x = 10;
            int y = 12;

            return new Point(x, y);
        }

        public static void Show(Polyline pl)
        {
            for (int i = 0; i < pl.Size; i++)
            {
                Point current = pl.GetPoint(i);
                Show(current);
            }
            Console.WriteLine();
        }

    }
}
