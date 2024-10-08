﻿using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Circle : Point, IGeometrical, IComparable
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

    public override PicItem[] GetView()
    {
        return new PicItem[]{
            new PicItem(CoordX, CoordY, _SYMBOL),
            new PicItem(CoordX - _r, CoordY, _SYMBOL),  //left
            new PicItem(CoordX + _r, CoordY, _SYMBOL),  //right
            new PicItem(CoordX, CoordY + _r, _SYMBOL),  //top
            new PicItem(CoordX, CoordY - _r, _SYMBOL)   //bottom
        };
    }

    public double GetArea()
    {
        return  Math.Pow(_r, 2) * Math.PI;
    }

    public int GetPerimeter()
    {
        return (int)(2 * _r * Math.PI);
    }

    public int CompareTo(object? obj)
    {
        Circle c2 = obj as Circle;

        if (c2 == null)
        {
            return 1;
        }

        if (GetArea() > c2.GetArea())
        {
            return 1;
        }

        if (GetArea() < c2.GetArea())
        {
            return -1;
        }

        return 0;
    }
}
