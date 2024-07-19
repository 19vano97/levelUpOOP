using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    public virtual void Rotate45()
    {}

    public virtual Figure2d[] GetView()
    {
        return new Figure2d[] { new Figure2d(_x, _y, '*') };
    }
    
}
