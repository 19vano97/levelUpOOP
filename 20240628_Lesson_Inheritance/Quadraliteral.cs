namespace _20240628_Lesson_Inheritance;

public abstract class Quadrilateral : Figure2d
    {
        protected int _width;    // довжина першої сторони

        public Quadrilateral(int x, int y, int width)
           : base(x, y)    // виклик конструктору батьківського класу з 2ма параметрами
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ctor Quadrilateral({0}, {1}, {2})", x, y, width);

            _width = width;
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _width = value;
            }
        }

        public override void Resize(float delta)
        {
            _width = (int)(_width * delta);
        }
    }
