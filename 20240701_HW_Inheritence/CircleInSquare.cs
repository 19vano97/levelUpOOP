namespace _20240701_HW_Inheritence;

public class CircleInSquare : Square
{
    private Circle _circleInSquare;

    public CircleInSquare(int x, int y, int length, Picture pictureFile) : base(x, y, length, pictureFile)
    {
        int xCentroid = (base.Points[0].CoordX + base.Points[3].CoordX) / 2;
        int yCentroid = (base.Points[0].CoordY + base.Points[3].CoordY) / 2;

        _circleInSquare = new Circle(xCentroid, yCentroid, length / 2, pictureFile);
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

    public override void Resize(Point[] points, int index)
    {
        base.Resize(points, index);
        _circleInSquare.Resize(index);
    }


}
