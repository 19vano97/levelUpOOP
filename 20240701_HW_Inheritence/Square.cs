namespace _20240701_HW_Inheritence;

public class Square : Quadrilateral
{
    protected Point[] _points;

    public Square(int x, int y, int length) : base(x, y, length)
    {
        _points = CalculatePoints(x, y, length);
    }

    public Square(Quadrilateral newQuadrilateral) : 
        this (newQuadrilateral.CoordX, newQuadrilateral.CoordY, newQuadrilateral.GetLength)
    {
        
    }

    public Point[] Points
    {
        get
        {
            return _points;
        }
    }
}
