using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace _20240701_HW_Inheritence;

public abstract class Figure2d
{
    #region variables

        protected int _x;
        protected int _y;
        
    #endregion

    #region default ctors

        public Figure2d(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Figure2d(Figure2d fig) : this(fig._x, fig._y)
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

    public abstract void Move(int x, int y);

    public abstract void Resize(double index);

    public abstract void Rotate45();

    public abstract PicItem[] GetView();

    // public abstract double GetArea();

    // public abstract int GetPerimeter();
}
