namespace _20240628_Lesson_Inheritance;

public abstract class Figure2d
    {
        #region ---=== protected data ===---

        protected int _x;
        protected int _y;

        #endregion

        #region ---===   Properies   ===---

        public int X
        {
            // accessor
            // виклакається коли властивість використовується
            // в правій частині оператору присвоювання
            get
            {
                return _x;
            }
            // accessor
            // виклакається коли властивість використовується
            // в лівій частині оператору присвоювання
            set
            {
                if (value < 0)
                {
                    return;
                }

                // value - права частина оператору присвоювання
                _x = value;
            }
        }

        public int Y
        {
            // accessor
            // виклакається коли властивість використовується
            // в правій частині оператору присвоювання
            get
            {
                return _y;
            }
            // accessor
            // виклакається коли властивість використовується
            // в лівій частині оператору присвоювання
            set
            {
                if (value < 0)
                {
                    return;
                }

                // value - права частина оператору присвоювання
                _y = value;
            }
        }

        #endregion

        public Figure2d(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ctor Figure2D({0}, {1})", x, y);
            _x = x;
            _y = y;
        }

        ~Figure2d()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("dtor Figure2D({0}, {1})", _x, _y);
        }

        public virtual void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        // абстрактний метод
        // не має реалізації в батьківському класі
        // визнчає поведінку для всіх похідних класів
        public abstract void Resize(float delta);

        public abstract PictItem[] GetView();
    }
