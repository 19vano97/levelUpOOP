namespace _20240701_HW_Inheritence;

public abstract class Quadrilateral : Point
{
    #region data
        protected int _length;
        protected const int AMOUNT_OF_ANGLES = 4;

    #endregion

    #region default ctors

        public Quadrilateral(int x, int y, int length, Picture pictureOwner) : base(x, y, pictureOwner)
        {
            _length = length;
        }

    #endregion

    public int Length 
    { 
        get
        {
            if (_length < 0)
            {
                return 0;
            }

            return _length;
        } 
        
        set
        {
            if (_length < 0)
            {
                return;
            }

            _length = value;
        } 
    }

    protected Point[] CalculatePoints(int x, int y, int length, int height = -1)
    {
        Point[] points = new Point[AMOUNT_OF_ANGLES];

        points[0] = new Point(x, y, base.PictureOwner);   //p1

        points[1] = new Point(x + length, y, base.PictureOwner);    //p2


        if (height <= -1)
        {
            points[2] = new Point(x, y + length, base.PictureOwner);    //p3
            points[3] = new Point(points[1].CoordX, y + length, base.PictureOwner);   //p4
        }
        else
        {
            points[2] = new Point(x, y + height, base.PictureOwner);    //p3
            points[3] = new Point(points[1].CoordX, y + height, base.PictureOwner);   //p4
        }

        return points;
    }

    public virtual void Resize(Point[] points, int index)
    {
        points[0].UpdatePoint(points[0].CoordX / index, points[0].CoordY / index);
        points[1].UpdatePoint(points[1].CoordX * index, points[1].CoordY / index);
        points[2].UpdatePoint(points[2].CoordX / index, points[2].CoordY * index);
        points[3].UpdatePoint(points[3].CoordX * index, points[3].CoordY / index);
    }

    public void Rotate45(Point[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            int newX = (int)((double)(Math.Sqrt(2) / 2) * (points[i].CoordX - points[i].CoordY));
            int newY = (int)((double)(Math.Sqrt(2) / 2) * (points[i].CoordX + points[i].CoordY));

            points[i].UpdatePoint(newX, newY);
        }
    }
    


}
