using System.ComponentModel;

namespace _20240701_HW_Inheritence;

public class Square : Quadrilateral
{
    protected Point[] _points;

    #region default ctors

        public Square(int x, int y, int length, Picture pictureOwner) : base(x, y, length, pictureOwner)
        {
            _points = CalculatePoints(x, y, length);
        }
    
        public Square(Quadrilateral newQuadrilateral) : 
            this (newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.Length, newQuadrilateral.PictureOwner)
        {
            
        }
        
    #endregion

    public Point[] Points
    {
        get
        {
            return _points;
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
}
