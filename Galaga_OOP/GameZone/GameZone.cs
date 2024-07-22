namespace Galaga_OOP;

public class GameZone
{
    private char[,] _gamezone;
    private int _x = Console.WindowWidth;
    private int _y = Console.WindowHeight - 5;

    public GameZone()
    {
        // int x = 155;
        // int y = 22;

        _gamezone = new char[_x, _y];
    }


}
