using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Square : Quadrilateral, IGeometrical, IComparable
{
    #region default ctors

        public Square(int x, int y, int length) : base(x, y, length)
        {
            CalculatePoints(x, y, length, 0);
        }
    
        public Square(Quadrilateral newQuadrilateral) : 
            this (newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.Length)
        {}   
        
        
    #endregion

    protected override void CalculatePoints(int x, int y, int length, int plug)
    {
        _points = new Point[Quadrilateral.AMOUNT_OF_ANGLES];

        _points[0] = new Point(x, y);   //p1
        _points[1] = new Point(x + length, y);    //p2
        _points[2] = new Point(x, y + length);    //p3
        _points[3] = new Point(x + length, y + length);   //p4
    }

    public double GetArea()
    {
        return Math.Pow(_length, 2);
    }

    public int GetPerimeter()
    {
        return _length * 4;
    }

    public int CompareTo(object? obj)
    {
        Square s2 = obj as Square;

        if (s2 == null)
        {
            return 1;
        }

        if (GetArea() > s2.GetArea())
        {
            return 1;
        }

        if (GetArea() < s2.GetArea())
        {
            return -1;
        }

        return 0;
    }
}
