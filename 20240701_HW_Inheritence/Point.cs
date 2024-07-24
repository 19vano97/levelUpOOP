using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _20240701_HW_Inheritence;

public class Point : Figure2d
{
    #region default ctors

        public Point(int x, int y) : base(x, y)
        {
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

    public void UpdatePoint(Point p)
    {
        _x = p._x;
        _y = p._y;
    }

    public override void Move(int x, int y)
    {
        _x += x;
        _y += y;
    }

    public override void Rotate45()
    {}

    public override void Resize(double index)
    {}

    // public override double GetArea()
    // {
    //     return 0d;
    // }

    // public override int GetPerimeter()
    // {
    //     return 0;
    // }

    public override PicItem[] GetView()
    {
        return new PicItem[] { new PicItem(_x, _y, '*') };
    }
    
}
