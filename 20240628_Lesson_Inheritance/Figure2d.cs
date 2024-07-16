namespace _20240628_Lesson_Inheritance;

public abstract class Figure2d
{
    #region variables

        protected int _x;
        protected int _y;

    #endregion

    public Figure2d(int x, int y)
    {
        _x = x;
        _y = y;
    }

    ~Figure2d()
    {
        
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

    public virtual void Move(int x, int y)
    {
        _x += x;
        _y += y;
    }

    public abstract void Resize(float delta);

    public abstract PicturePoint[] GetView();
}
