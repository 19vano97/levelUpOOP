using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Square : Quadrilateral, IGeometrical
{
    protected const char _SYMBOL = '#';
    // protected Point[] _points;

    #region default ctors

        public Square(int x, int y, int length) : base(x, y, length)
        {
            CalculatePoints(x, y, length, 0);
        }
    
        public Square(Quadrilateral newQuadrilateral) : 
            this (newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.Length)
        {}   
        
        
    #endregion

    public Point[] Points
    {
        get
        {
            return _points;
        }
    }

    public override void Move(int x, int y)
    {
        for (int i = 0; i < _points.Length; i++)
        {
                _points[i].UpdatePoint(_points[i].CoordX + x, _points[i].CoordY + y);
        }

        base.CoordX += x;
        base.CoordY += y;
    }

    protected override void CalculatePoints(int x, int y, int length, int plug)
    {
        _points = new Point[Quadrilateral.AMOUNT_OF_ANGLES];

        _points[0] = new Point(x, y);   //p1
        _points[1] = new Point(x + length, y);    //p2
        _points[2] = new Point(x, y + length);    //p3
        _points[3] = new Point(x + length, y + length);   //p4
    }

    public override PicItem[] GetView()
    {
        PicItem[] figure2Ds = new PicItem[_points.Length];

        for (int i = 0; i < figure2Ds.Length; i++)
        {
            figure2Ds[i] = new PicItem(_points[i].CoordX, _points[i].CoordY, _SYMBOL);
        }

        return figure2Ds;
    }

    public override double GetArea()
    {
        return Math.Sqrt(_length);
    }

    public override int GetPerimeter()
    {
        return _length * 4;
    }
}
