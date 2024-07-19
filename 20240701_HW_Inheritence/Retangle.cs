namespace _20240701_HW_Inheritence;

public class Rectangle : Quadrilateral
{
    #region data
        protected const char _SYMBOL = '|';
        protected int _height;
        protected Point[] _points;

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

    protected override void CalculatePoints(int x, int y, int length, int height)
    {
        _points = new Point[Quadrilateral.AMOUNT_OF_ANGLES];
        
        _points[0] = new Point(x, y);   //p1
        _points[1] = new Point(x + length, y);    //p2
        _points[2] = new Point(x, y + height);    //p3
        _points[3] = new Point(_points[1].CoordX, y + height);   //p4
    }

    public override void Rotate45()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            int newX = (int)((double)(Math.Sqrt(2) / 2) * (_points[i].CoordX - _points[i].CoordY));
            int newY = (int)((double)(Math.Sqrt(2) / 2) * (_points[i].CoordX + _points[i].CoordY));

            _points[i].UpdatePoint(newX, newY);
        }
    }

    public override Figure2d[] GetView()
    {
        Figure2d[] figure2Ds = new Figure2d[_points.Length];

        for (int i = 0; i < figure2Ds.Length; i++)
        {
            figure2Ds[i] = new Figure2d(_points[i].CoordX, _points[i].CoordY, _SYMBOL);
        }

        return figure2Ds;
    }

}
