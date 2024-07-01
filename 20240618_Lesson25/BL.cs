using System;

using _20240610_IncapsulationDemo;

namespace _20240509_StructsDemo
{
    public class BL
    {
        public static void Move(ref Point p, int dx, int dy)
        {
            //int newXCoord = p.GetX() + dx;
            //int newYCoord = p.GetY() + dy;

            //p.SetX(newXCoord);
            //p.SetY(newYCoord);

            p.X += dx;
            p.Y += dy;
        }

        public static void Move(ref Polyline pl, int dx, int dy)
        {
            //for (int i = 0; i < pl.GetSize(); i++)
            for (int i = 0; i < pl.Size; i++)
            {
                // (1)
                //int newXCoord = pl.GetPoint(i).GetX() + dx;
                //int newYCoord = pl.GetPoint(i).GetY() + dy;

                //pl.SetPoint(i, new Point(newXCoord, newYCoord));

                // (2)
                // Point current = pl.GetPoint(i);
                // Move(ref current, dx, dy);
                // pl.SetPoint(i, current);

                //(3)
                Point current = pl[i];
                Move(ref current, dx, dy);
                pl[i] = current;
            }
        }

        //public static int GetCapacity(Polyline pl)
        //{
        //    return pl.Points.Length;
        //}

        // Factory method - метод, обов'язок якого ініціалізувати іншу структуру (або клас)
        //public static Polyline Create(int capacity = Polyline.DEFAULT_CAPACITY)
        //{
        //    Polyline pl = new Polyline()
        //    {
        //        Size = 0,
        //        Points = new Point2D[capacity]
        //    };

        //    return pl;
        //}

        //public static Polyline Create(Point2D p1, Point2D p2)
        //{
        //    Polyline pl = Create();

        //    AddPoint(ref pl, p1);
        //    AddPoint(ref pl, p2);

        //    return pl;
        //}

        //public static Polyline Create(params Point2D[] points)
        //{
        //    int capacity = points.Length;
        //    if (Polyline.DEFAULT_CAPACITY > capacity)
        //    {
        //        capacity = Polyline.DEFAULT_CAPACITY;
        //    }

        //    Polyline pl = new Polyline(capacity);

        //    for (int i = 0; i < points.Length; i++)
        //    {
        //        AddPoint(ref pl, points[i]);
        //    }

        //    return pl;
        //}


        // !!!
        //public static Polyline GetFullCopy(Polyline source)
        //{
        //    Polyline destination = source;    // копіювання полів типу значення
        //    // копіювання полів посилального типу
        //    destination.Points = (Point2D[])source.Points.Clone();

        //    return destination;
        //}

        //#region ---  Polyline CRUD-operations  ---- 

        //// Create
        //public static void AddPoint(ref Polyline pl, Point p)
        //{
        //    if (pl._size >= GetCapacity(pl))
        //    {
        //        // ToDo: set new size
        //        Array.Resize(ref pl._points, pl.Points.Length * 2);
        //    }

        //    pl._points[pl._size++] = p;
        //}

        //public static Point DelelePoint(ref Polyline pl, int position)
        //{
        //    Point deleted = pl._points[position];

        //    for (int i = position; i < pl._size - 1; i++)
        //    {
        //        pl._points[i] = pl._points[i + 1];
        //    }

        //    --pl._size;

        //    return deleted;
        //}

        //public static bool TryDelelePoint(ref Polyline pl, Point p)
        //{
        //    int pos = FindPosition(pl, p);

        //    bool ok = pos != -1;

        //    if (!ok)
        //    {
        //        return ok;
        //    }

        //    DelelePoint(ref pl, pos);

        //    return ok;
        //}

        //// Read
        //public static int FindPosition(Polyline pl, Point p)
        //{ 
        //    int index = -1;

        //    for (int i = 0; i < pl._size; i++)
        //    {
        //        if (pl._points[i].GetX() == p.GetX() && pl._points[i].GetY() == p.GetY())
        //        {
        //            index = i;
        //            break;
        //        }
        //    }

        //    return index;
        //}

        //public static bool UpdatePoint(Polyline pl, Point source, Point destination)
        //{
        //    int pos = FindPosition(pl, source);

        //    bool ok = pos != -1;

        //    if (!ok)
        //    {
        //        return ok;
        //    }

        //    pl._points[pos] = destination;

        //    return ok;
        //}

        //#endregion
    }
}
