namespace _20240701_HW_Inheritence;

public abstract class Quadrilateral : Point
{
    #region data

        protected const int AMOUNT_OF_ANGLES = 4;
        protected int _length;
        protected Point[] _points = null;
        protected const char _SYMBOL = '#'; 

    #endregion

    #region default ctors

        public Quadrilateral(int x, int y, int length) : base(x, y)
        {
            _length = length;
        }

    #endregion

    public Point[] Points
    {
        get
        {
            return _points;
        }
    }

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

    public override void Resize(double index)
    {
        _length *= (int)index;
        
        _points[0].UpdatePoint(_points[0].CoordX / (int)index, _points[0].CoordY / (int)index);
        _points[1].UpdatePoint(_points[1].CoordX * (int)index, _points[1].CoordY / (int)index);
        _points[2].UpdatePoint(_points[2].CoordX / (int)index, _points[2].CoordY * (int)index);
        _points[3].UpdatePoint(_points[3].CoordX * (int)index, _points[3].CoordY * (int)index);
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

    public override void Move(int x, int y)
    {
        for (int i = 0; i < _points.Length; i++)
        {
                _points[i].UpdatePoint(_points[i].CoordX + x, _points[i].CoordY + y);
        }

        base.CoordX += x;
        base.CoordY += y;
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

    protected abstract void CalculatePoints(int x, int y, int length, int height = 0);

}
