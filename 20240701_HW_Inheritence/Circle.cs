using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Circle : Point
{
    protected char _SYMBOL = '*';
    private int _r;

    public Circle(int x, int y, int radius) : base (x, y)
    {
        _r = radius;

    }

    public int Radius
    {
        get
        {
            return _r;
        }
        set
        {
            if (_r <= 0)
            {
                return;
            }

            _r = value;
        }
    }

    public char Symbol
    {
        get
        {
            return _SYMBOL;
        }
    }

    public void Update(int x, int y, int r)
    {
        CoordX = x;
        CoordY = y;
        _r= r;
    }

    
    public override void Resize(double index)
    {
        _r *= (int)index;
    }

    public override Figure2d[] GetView()
    {
        return new Figure2d[]{
            new Figure2d(CoordX, CoordY, _SYMBOL),
            new Figure2d(CoordX - _r, CoordY, _SYMBOL),  //left
            new Figure2d(CoordX + _r, CoordY, _SYMBOL),  //right
            new Figure2d(CoordX, CoordY + _r, _SYMBOL),  //top
            new Figure2d(CoordX, CoordY - _r, _SYMBOL)   //bottom
        };
    }
}
