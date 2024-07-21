using System.Data.SqlTypes;

namespace _20240701_HW_Inheritence;

public class CircleInSquare : Square
{
    private Circle _circleInSquare;

    public CircleInSquare(int x, int y, int length) : base(x, y, length)
    {
        int[] circleCenter = FindCenterOfSquare();
        _circleInSquare = new Circle(circleCenter[0], circleCenter[0], length / 2);
    }

    public CircleInSquare(Square sqr) : this(sqr.Points[0].CoordX, sqr.Points[0].CoordY, sqr.Length)
    {
    }

    // public Circle UseCircle
    // {
    //     get
    //     {
    //         return new Circle((base.Points[0].CoordX + base.Points[3].CoordX) / 2, 
    //             (base.Points[0].CoordY + base.Points[3].CoordY) / 2, Length / 2, _pictureOwner);
    //     }
    // }

    public Circle UseCircle
    {
        get
        {
            return _circleInSquare;
        }
    }

    protected int[] FindCenterOfSquare()
    {
        int xCentroid = (base.Points[0].CoordX + base.Points[3].CoordX) / 2;
        int yCentroid = (base.Points[0].CoordY + base.Points[3].CoordY) / 2;

        return [xCentroid, yCentroid];
    }

    public override void Resize(double index)
    {
        base.Resize(index);
        
        int[] circleCenter = FindCenterOfSquare();

        _circleInSquare.Update(circleCenter[0], circleCenter[1], _circleInSquare.Radius);

        _circleInSquare.Resize(index);
    }

    public override PicItem[] GetView()
    {
        PicItem[] figures = new PicItem[Points.Length + _circleInSquare.GetView().Length];

        for (int i = 0; i < Points.Length; i++)
        {
            figures[i].x = Points[i].CoordX;
            figures[i].y = Points[i].CoordY;
            figures[i].symdol = _SYMBOL;
        }

        for (int i = Points.Length; i < figures.Length; i++)
        {
            figures[i].x = _circleInSquare.CoordX;
            figures[i].y = _circleInSquare.CoordY;
            figures[i].symdol = _circleInSquare.Symbol;
        }

        return figures;
    }


}
