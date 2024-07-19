namespace _20240628_Lesson_Inheritance;

public class Square : Quadrilateral
    {
        public Square(int x, int y, int width)
           : base(x, y, width)    // виклик конструктору батьківського класу з 2ма параметрами
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ctor Sqare({0}, {1}, {2})", x, y, width);
        }

        public override PictItem[] GetView()
        {
            return new PictItem[]
            {
                new PictItem() { X = _x, Y = _y, Symbol = '.' },
                new PictItem() { X = _x + _width, Y = _y, Symbol = '.' },
                new PictItem() { X = _x - + _width, Y = _y + _width, Symbol = '.' },
                new PictItem() { X = _x, Y = _y + _width, Symbol = '.' },
            };
        }
    }
