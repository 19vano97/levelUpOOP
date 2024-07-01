using System;

using _20240509_StructsDemo;

namespace _20240610_IncapsulationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p0 = new Point();    // (0, 0)

            //p0.Color = ConsoleColor.Red;

            //ConsoleColor c = p0.Color;


            BL.Move(ref p0, 5, 7);    // static method (utility)

            p0.Move(5, -2);

            Point p1 = new Point(12, 4);

            // int x1 = p1._x;
            int x1 = p1.X;    // int x1 = p1.GetX();    // member function call
            int y1 = p1.Y;    // int y1 = p1.GetY();    // member function call

            int x2 = p0.X;    // int x2 = p0.GetX();    // member function call
            int y2 = p0.Y;    // int y2 = p0.GetY();    // member function call

            // p0._y = 10;
            p0.Y = 10;    // p0.SetY(10);
            p0.X = -10; // p0.SetX(-10);
            if (p0.Error != ErrorState.Success)
            {
                Console.WriteLine("Error!!! Wrong operation!!!");
            }

            p0.X = 15;    // p0.SetX(15);

            UI.Show(p0);
            UI.Show(p1);
            UI.Show(p1);
            UI.Show(p1);

            Console.ReadKey();

            Point p1Copy = p1;

            //p1Copy.SetY(14);
            p1Copy.Y = 14;

            Console.ForegroundColor = ConsoleColor.Green;

            UI.Show(p1);
            UI.Show(p1Copy);

            Point p2 = new Point(23, 14);

            Polyline poly1 = new Polyline(p1, p2, new Point(34, 3));

            Polyline poly2 = new Polyline(5);

            Polyline poly3 = new Polyline(p1, p2, new Point(17));

            Console.ReadKey();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            UI.Show(poly3);

            Point p10 = new Point(23, 4);

            if (poly3[p10])
            {
                
            }
            
            if (poly3[4, 5])
            {
                
            }

            Console.ReadKey();
        }
    }
}
