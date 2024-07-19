using System.Security.Cryptography.X509Certificates;

namespace _20240701_HW_Inheritence;

public class Figure2d
{
    #region variables

        private int _x;
        private int _y;
        private char _symbol;
        
    #endregion

    #region default ctors

        public Figure2d(int x, int y, char symbol)
        {
            _x = x;
            _y = y;
            _symbol = symbol;
        }

        public Figure2d(Figure2d fig) : this(fig._x, fig._y, fig._symbol)
        {}
        
    #endregion
    
    public int X
    {
        get
        {
            if (_x < 0)
            {
                return 0;
            }

            return _x;
        }

        set
        {
            if (_x < 0)
            {
                return;
            }

            _x = value;
        }
    }

    public int Y
    {
        get
        {
            if (_y < 0)
            {
                return 0;
            }

            return _y;
        }

        set
        {
            if (_y < 0)
            {
                return;
            }

            _y = value;
        }
    }

    public char Symbol
    {
        get
        {
            if (_symbol == null)
            {
                return ' ';
            }

            return _symbol;
        }
        set
        {
            if (_symbol == null)
            {
                return;
            }

            _symbol = value;
        }
    }

    public void ReplaceParams(Figure2d fig2)
    {
        _x = fig2._x;
        _y = fig2._y;
        _symbol = fig2._symbol;
    }
}
