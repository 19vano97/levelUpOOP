using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Circle : Point
{
    private int _r;
    private Point[] _points;

    public Circle(int x, int y, int radius, Picture pictureOwner) : base (x, y, pictureOwner)
    {
        _r = radius;
        CalculateCirclePoints();
    }

    public Point[] Points 
    { 
        get
        { 
            return _points; 
        }
    }

    public int Radius
    {
        get
        {
            return _r;
        }
    }

    private void CalculateCirclePoints()
    {
        _points = new Point[5];

        _points[0] = new Point(base.CoordX, base.CoordY, base.PictureOwner);   //radiusPoint
        _points[1] = new Point(base.CoordX, base.CoordY + _r, base.PictureOwner);   //top
        _points[2] = new Point(base.CoordX - _r, base.CoordY, base.PictureOwner);   //left
        _points[3] = new Point(base.CoordX, base.CoordY - _r, base.PictureOwner);   //bottom
        _points[4] = new Point(base.CoordX + _r, base.CoordY, base.PictureOwner);   //right

    }

    // public void Resize(int index)
    // {
    //     _r = _r * index;
    //     // _points[0].UpdatePoint(_points[0].CoordX * index, _points[0].CoordY * index);
    //     _points[1].UpdatePoint(_points[1].CoordX, _points[1].CoordY * index);   //top
    //     _points[2].UpdatePoint(_points[2].CoordX / index, _points[2].CoordY);   //left
    //     _points[3].UpdatePoint(_points[3].CoordX, _points[3].CoordY / index);   //bottom
    //     _points[4].UpdatePoint(_points[4].CoordX * index, _points[4].CoordY);   //right
    // }
    
    public void Resize(int index)
    {
        _r = _r * index;
        // _points[0].UpdatePoint(_points[0].CoordX * index, _points[0].CoordY * index);
        _points[1].UpdatePoint(base.CoordX, base.CoordY + _r);   //top
        _points[2].UpdatePoint(base.CoordX - _r, base.CoordY);   //left
        _points[3].UpdatePoint(base.CoordX, base.CoordY - _r);   //bottom
        _points[4].UpdatePoint(base.CoordX + _r, base.CoordY);   //right
    }
}
