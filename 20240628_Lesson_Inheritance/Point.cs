using System.Reflection;

namespace _20240628_Lesson_Inheritance;


    public class CheckPoint : Figure2d
    {

    

        public CheckPoint(int x, int y) : base(x, y)
        {
        }

        public CheckPoint(int coord) : this(coord, coord)
        {
        }

        
        //destructor
        ~CheckPoint()
        {
            
        }

        public CheckPoint()
            :this (0, 0)
        {
            System.Console.WriteLine("ctor Point({0})");
        }

        public CheckPoint(CheckPoint source)
            : this(source._x, source._y)
        {
            //copy point
        }

    public override void Resize(float delta)
    {
        _x += (int)delta;
        _y += (int)delta;
    }

    public override PicturePoint[] GetView()
    {
        throw new NotImplementedException();
    }

    // public override PicturePoint[] GetView()
    // {
    //     return new PicturePoint() {new PicturePoint() {x= _x, y = _y, symbol = '.'}};
    // }
}
