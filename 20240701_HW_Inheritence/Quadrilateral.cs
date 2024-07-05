namespace _20240701_HW_Inheritence;

public class Quadrilateral : Point
{
    #region data
        protected int _length;
        protected const int AMOUNT_OF_ANGLES = 4;

    #endregion

    #region default ctors

        public Quadrilateral(int x, int y, int length) : base(x, y)
        {
            _length = length;
        }

    #endregion

    public int GetLength 
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
        #region DEBUG
            int consoleX = 100;
            int consoleY = 25;
        #endregion

        // int consoleX = Console.WindowWidth;
        // int consoleY = Console.WindowHeight;

        Point[] points = new Point[AMOUNT_OF_ANGLES];

        points[0] = new Point(x, y);   //p1

        if (x + length < consoleX)
        {
            points[1] = new Point(x + length, y);    //p2
        }
        else
        {
            points[1] = new Point(x - length, y);    //p2
        }

        if (height <= -1)
        {
            if (y + height < consoleY)
            {
                points[2] = new Point(x, y + length);    //p3
                points[3] = new Point(points[1].CoordX, y + length);   //p4
            }
            else
            {
                points[2] = new Point(x, y - length);    //p3
                points[3] = new Point(points[1].CoordX, y - length);   //p4
            }
        }
        else
        {
            if (y + length < consoleY)
            {
                points[2] = new Point(x, y + height);    //p3
                points[3] = new Point(points[1].CoordX, y + height);   //p4
            }
            else
            {
                points[2] = new Point(x, y - height);    //p3
                points[3] = new Point(points[1].CoordX, y - height);   //p4
            }
        }

        return points;
    }

    public void Resize(Point[] points, int index)
    {
        points[0].SetPoint(points[0].CoordX, points[0].CoordY);
        points[1].SetPoint(points[1].CoordX * index, points[1].CoordY);
        points[2].SetPoint(points[2].CoordX, points[2].CoordY * index);
        points[3].SetPoint(points[3].CoordX * index, points[3].CoordY * index);
    }

    public void Rotate45(Point[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            int newX = (int)((double)(Math.Sqrt(2) / 2) * (points[i].CoordX - points[i].CoordY));
            int newY = (int)((double)(Math.Sqrt(2) / 2) * (points[i].CoordX + points[i].CoordY));

            points[i].SetPoint(newX, newY);
        }
    }
    


}
