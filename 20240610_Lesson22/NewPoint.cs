using System.Diagnostics.Contracts;

namespace _20240610_Lesson22;

public struct NewPoint
{
    private int _x;
    private int _y;

    private ErrorState _error;

    public NewPoint(int x, int y)
    {
        _x = x;
        _y = y;
        _color = ConsoleColor.DarkRed;
        _error = ErrorState.Success;
    }

    //getters

    public int GetX()
    {
        return _x;
    }

    public int GetY()
    {
        return _y;
    }

    //setters

    public void SetX(int x)
    {
        if (x < 0)
        {
            _error = ErrorState.XLessZero;
            return;
        }
        
        _x = x;
    
    }
    public void SetY(int y)
    {
        if (y < 0)
        {
            _error = ErrorState.YLessZero;
            return;
        }

        _y = y;
    }

    public ErrorState GetError()
    {
        return _error;
    }

    public void Move(int dx, int dy)
    {
        _x += dx;
        _y += dy;
    }

    private ConsoleColor _color;    //field

    //property to have access to the field
    public ConsoleColor Color
    {
        //accessor to get value
        get 
        { 
            return _color; 
        }

        //accessor to set value
        set 
        {
            //value - the right side of the assignment operator
            _color = value; 
        }
    }

    //set only - restricted, it can be used to get but no single set
    //get/set should be called faste. no long and complicated logic
    //dont use external libs, apps to call get/set. it should be separate func

    private int propX;
    public int MyProperty
    {
        get { return propX; }
        set 
        {
            if (value < 0)
            {
                return;
            }

            propX = value; 
            _error = ErrorState.Success;
        }
    }
    
    
}
