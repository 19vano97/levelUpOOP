
namespace _20240701_HW_Inheritence;

public class Point
{
    #region data

        private int _x;
        private int _y;

    #endregion

    #region default ctors

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    
        public Point() : this (0, 0)
        {}

    #endregion

    public int CoordX 
    { 
        get{return _x;}
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

    public void UpdatePoint(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
