using System.Drawing;

namespace _20240610_Lesson22;

public class UI
{
    public static void Show(NewPoint p)
    {
        Show(p.GetX(), p.GetY());
    }

    public static NewPoint InputPoint()
    {
        return new NewPoint(10, 12);
    }

    public static void Show(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        System.Console.Write('*');
    }

}
