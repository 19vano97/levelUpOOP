namespace _20240701_HW_Inheritence;

public class Point
{
    #region data

        private int _x;
        private int _y;
        protected Picture _pictureOwner;

    #endregion

    #region default ctors

        public Point(int x, int y, Picture pictureOwner)
        {
            _x = x;
            _y = y;
            _pictureOwner = pictureOwner;
        }
    
        public Point(Picture pictureOwner) : this (0, 0, pictureOwner)
        {}

    #endregion

    public int CoordX 
    { 
        get
        {
            return _x;
        }
        set
        {
            if (_x < 0)
            {
                return;
            }

            _x = value;
        }
    }

    public int CoordY
    { 
        get
        { return _y; } 
        
        set
        {
            if (_y < 0)
            {
                return;
            }

            _y = value;
        }
    }

    public Picture PictureOwner
    {
        get
        {
            return _pictureOwner;
        }
    }

    public void UpdatePoint(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public virtual void Move(int x, int y)
    {
        _x += x;
        _y += y;
    }

    public virtual void Resize(double index)
    {}
}
