using System.Drawing;

namespace _20240628_Lesson_Inheritance;

public class Circle : CheckPoint
{
    private int _r;

    public Circle(int x, int y, int r)
        : base(x,  y) // is a key word that uses to call the parrent class
    {
        _r = r;
    }

    public int GetCircle 
    { 
        get
        {
            return _r;
        }
        set
        {
            _r = value;
        }
    }
    
    
}
