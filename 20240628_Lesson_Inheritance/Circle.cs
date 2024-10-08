﻿using System.Drawing;

namespace _20240628_Lesson_Inheritance;

public class Circle : CheckPoint
{
    private int _r;

    public Circle(int x, int y, int r)
        : base(x,  y)
    {
        _r = r;
    }

    public int GetCircle 
    { 
        get
        {
            return _r;
        }
        set
        {
            _r = value;
        }
    }

    public override void Resize(float delta)
    {
        _r *= (int)delta;
    }



}
