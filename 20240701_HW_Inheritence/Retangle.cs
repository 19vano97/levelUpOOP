namespace _20240701_HW_Inheritence;

public class Rectangle : Quadrilateral, IGeometrical, IComparable
{
    #region variables

        protected int _height;

    #endregion

    #region default ctors

        public Rectangle(int x, int y, int length, int height) : base(x, y, length)
        {
            _height = height;
            CalculatePoints(x, y, length, _height);
        }
    
        public Rectangle(Quadrilateral newQuadrilateral, int height) : 
            this(newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.Length, height)
        {}
        
    #endregion


    public int heightOfRectangle
    {
        get
        {
            if (_height < 0)
            {
                return 0;
            }

            return _height;
        }
        set
        {
            if (_height < 0)
            {
                return;
            }

            _height = value;
        }
    }

    protected override void CalculatePoints(int x, int y, int length, int height)
    {
        _points = new Point[Quadrilateral.AMOUNT_OF_ANGLES];
        
        _points[0] = new Point(x, y);   //p1
        _points[1] = new Point(x + length, y);    //p2
        _points[2] = new Point(x, y + height);    //p3
        _points[3] = new Point(_points[1].CoordX, y + height);   //p4
    }

    public double GetArea()
    {
        return _length * _height;
    }

    public int GetPerimeter()
    {
        return 2 * (_length + _height);
    }

    public override void Resize(double index)
    {
        _length *= (int)index;
        _height *= (int)index;
        
        _points[0].UpdatePoint(_points[0].CoordX / (int)index, _points[0].CoordY / (int)index);
        _points[1].UpdatePoint(_points[1].CoordX * (int)index, _points[1].CoordY / (int)index);
        _points[2].UpdatePoint(_points[2].CoordX / (int)index, _points[2].CoordY * (int)index);
        _points[3].UpdatePoint(_points[3].CoordX * (int)index, _points[3].CoordY * (int)index);
    }

    public int CompareTo(object? obj)
    {
        Rectangle r2 = obj as Rectangle;

        if (r2 == null)
        {
            return 1;
        }

        if (GetArea() > r2.GetArea())
        {
            return 1;
        }

        if (GetArea() < r2.GetArea())
        {
            return -1;
        }

        return 0;
    }
}
