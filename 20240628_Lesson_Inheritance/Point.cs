using System.Reflection;

namespace _20240628_Lesson_Inheritance;


    public class CheckPoint : Figure2d
    {
        #region ---=== methods for data processing ===---

        public CheckPoint(int x, int y) : base(x, y) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ctor Point({0}, {1})", x, y);
        }

        public CheckPoint(int coord) : base(coord, coord)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ctor Point({0})", coord);
        }

        // ctor copy
        public CheckPoint(CheckPoint source)
             : base(source._x, source._y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ctor Point(Point({0}, {1}))", source._x, source._y);
        }

        // destructor - dtor
        ~CheckPoint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("dtor Point({0}, {1})", _x, _y);
        }

        #endregion

        public override void Resize(double delta)
        {
        }

        public override PictItem[] GetView()
        {
            return new PictItem[] { new PictItem() { X = _x, Y = _y, Symbol = '.' } };
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", _x, _y);
        }

        public virtual void Rotate45()
        {}
}
