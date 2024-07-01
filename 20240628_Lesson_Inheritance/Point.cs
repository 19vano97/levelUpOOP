namespace _20240628_Lesson_Inheritance;


    public class CheckPoint
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

    

        #endregion

        #region ---=== methods for data processing ===---

        public CheckPoint(int x, int y)
        {
            _x = x;
            _y = y;

            //_color = ConsoleColor.Green;

        }

        public CheckPoint(int coord) : this(coord, coord)
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

        // read only property


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
        ~CheckPoint()
        {
            
        }

        // public Point(int coord) : this(coord, coord)
        // {

        // }

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
        
    }
