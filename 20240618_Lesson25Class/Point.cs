namespace _20240618_Lesson25Class;


    public class Point
    {
        #region ---=== private data ===---

        private int _x;
        private int _y;

        private static int _instanceCount = 0;

        public static int InstanceCount
        {
            get{return InstanceCount;}
            set{InstanceCount = value;}
        }

        private ErrorState _error;

        #endregion

        #region ---=== methods for data processing ===---

        public Point(int x, int y)
        {
            _x = x;
            _y = y;

            //_color = ConsoleColor.Green;

            _error = ErrorState.Success;
        }

        public Point(int coord) : this(coord, coord)
        {
        }

        // getters
        //public int GetX()
        //{
        //    _error = ErrorState.Success;
        //    return _x;
        //}

        //public int GetY()
        //{
        //    _error = ErrorState.Success;
        //    return _y;
        //}

        // setters
        //public void SetX(int x) 
        //{
        //    // validation
        //    if (x < 0)
        //    {
        //        _error = ErrorState.YLessZerro;
        //        return;
        //    }

        //    // <field> = <variable> 
        //    _x = x;
        //    _error = ErrorState.Success;
        //}

        //public void SetY(int y)
        //{
        //    // validation
        //    if (y < 0)
        //    {
        //        _error = ErrorState.YLessZerro;
        //        return;
        //    }

        //    // <field> = <variable> 
        //    _y = y;
        //    _error = ErrorState.Success;
        //}

        //public ErrorState GetError() 
        //{
        //    return _error;
        //}

        #endregion

        #region ---===   Properies   ===---

        //private ConsoleColor _color;    // field
        
        //// property for access to field
        //public ConsoleColor Color
        //{
        //    // accessor
        //    // виклакається коли властивість використовується в правій частині оператору присвоювання
        //    get
        //    { 
        //        return _color; 
        //    }
        //    // accessor
        //    // виклакається коли властивість використовується в лівій частині оператору присвоювання
        //    set
        //    {
        //        // value - права частина оператору присвоювання
        //        _color = value; 
        //    }
        //}

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
                    _error = ErrorState.YLessZerro;
                    return;
                }

                // value - права частина оператору присвоювання
                _x = value;
                _error = ErrorState.Success;
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
                    _error = ErrorState.YLessZerro;
                    return;
                }

                // value - права частина оператору присвоювання
                _y = value;
                _error = ErrorState.Success;
            }
        }

        // read only property
        public ErrorState Error
        {
            get
            { 
                return _error; 
            }
        }

        // write only
        // !!! Заборонено за кодінг конвеншенами !!!
        //public int Test
        //{
        //    set
        //    {
        //        int t = value;
        //        // ...
        //    }
        //}

        #endregion

        public void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        //destructor
        ~Point()
        {
            
        }

        // public Point(int coord) : this(coord, coord)
        // {

        // }

        public Point()
            :this (0, 0)
        {
            System.Console.WriteLine("ctor Point({0})");
        }

        public Point(Point source)
            : this(source._x, source._y)
        {
            //copy point
        }
        

        // public Point(Point source)
        // {
        //     _x = source._x;
        //     _y = source._y;
        //     _error = source._error;
        // }

        // public Point()
        // {
        //     _x = 0;
        //     _y = 0;
        // }
    }
