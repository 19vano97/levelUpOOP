namespace _20240701_HW_Inheritence;

public class Rectangle : Quadrilateral
{
    #region data

        protected int _height;
        protected Point[] _points = new Point[AMOUNT_OF_ANGLES];

    #endregion

    public Rectangle(int x, int y, int length, int height) : base(x, y, length)
    {
        _height = height;
        _points = CalculatePoints(x, y, length, _height);
    }

    public Rectangle(Quadrilateral newQuadrilateral, int height) : 
        this(newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.GetLength, height)
    {}


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

}
