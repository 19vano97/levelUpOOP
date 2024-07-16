namespace _20240701_HW_Inheritence;

public class Rectangle : Quadrilateral
{
    #region data

        protected int _height;
        protected Point[] _points = new Point[AMOUNT_OF_ANGLES];

    #endregion

    #region default ctors

        public Rectangle(int x, int y, int length, int height, Picture pictureOwner) : base(x, y, length, pictureOwner)
        {
            _height = height;
            _points = CalculatePoints(x, y, length, _height);
        }
    
        public Rectangle(Quadrilateral newQuadrilateral, int height) : 
            this(newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.Length, height, newQuadrilateral.PictureOwner)
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

}
