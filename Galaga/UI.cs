using System.ComponentModel;

namespace Galaga;

public class UI
{
    public static char GetHeroSymbol()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        char hero = '\u4DCC';

        return hero;
    }

    public static char GetEnemySymbol()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        char enemy = 'A';

        return enemy;
    }

    public static void SetDefaultPosition(char[,] gamezone)
    {
        Console.SetCursorPosition(gamezone.GetLength(0) / 2, gamezone.GetLength(1) - 1);
    }

    public static Position GetDefaultPosition(char[,] gamezone)
    {
        Position defaultPosition = new Position ()
        {
            x = gamezone.GetLength(0) / 2, 
            y = gamezone.GetLength(1) - 1
        };

        return defaultPosition;
    }

    public static char[,] PrintEnemy(ref char[,] gamezone, ref Spaceship enemy)
    {
        Console.SetCursorPosition(enemy.spaceshipCoodinates.x, enemy.spaceshipCoodinates.y);
        gamezone[enemy.spaceshipCoodinates.x, enemy.spaceshipCoodinates.y] = enemy.symbol;
        System.Console.Write(enemy.symbol);

        return gamezone;
    }

    public static void PrintShortInfoAboutSpaceShip(char[,] gamezone, Spaceship spaceshipInfo, int score)
    {
        int x = gamezone.GetLength(0) - 15;
        int y = gamezone.GetLength(1) + 1;

        for (int i = 0; i < 15; i++)
        {
            if (i == 0)
            {
                Console.SetCursorPosition(x + i, y);
                System.Console.Write('┏');
            }
            else
            {
                Console.SetCursorPosition(x + i, y);
                System.Console.Write('━');
            }
        }

        for (int i = 1; i < 4; i++)
        {
            Console.SetCursorPosition(x, y + i);
            System.Console.Write('┃');
        }

        for (int i = x + 2; i < gamezone.GetLength(0); i++)
        {
            Console.SetCursorPosition(i, y + 1);
            System.Console.Write(' ');
        }
        
        Console.SetCursorPosition(x + 2, y + 1);
        System.Console.WriteLine("HP: {0}", spaceshipInfo.healthPoint);
        Console.SetCursorPosition(x + 2, y + 2);
        System.Console.WriteLine("Score: {0}", score);
    }

    public static void PrintShortInfoAboutSpaceShip(Spaceship[] allSpaceships)
    {
        for (int i = 0; i < allSpaceships.Length; i++)
        {
            System.Console.WriteLine("id: {0}, HP: {1}", allSpaceships[i].id, allSpaceships[i].healthPoint);
        }
    }

    public static int GetIntInput(string message)
    {
        System.Console.Write("Enter {0}: ", message);

        string str = Console.ReadLine();

        if (int.TryParse(str, out int value))
        {
            return value;
        }
        else
        {
            value = GetIntInput(message);
            return value;
        }
    }

    public static void PrintScreenOfGamezone(char[,] gamezone)
    {
        // Bottom + Top
        for (int i = 0; i <= gamezone.GetLength(0); i++)
        {
            if (i == 0)
            {
                Console.SetCursorPosition(i, gamezone.GetLength(1));
                System.Console.Write('┗');
                Console.SetCursorPosition(i, 0);
                System.Console.Write('┏');
            }
            else if (i == gamezone.GetLength(0))
            {
                Console.SetCursorPosition(i, gamezone.GetLength(1));
                System.Console.Write('┛');
                Console.SetCursorPosition(i, 0);
                System.Console.Write('┓');
            }
            else
            {
                Console.SetCursorPosition(i, gamezone.GetLength(1));
                System.Console.Write('━');
            }
        }

        for (int i = 0; i < gamezone.GetLength(1); i++)
        {
            Console.SetCursorPosition(0, i);
            System.Console.Write('┃');
            Console.SetCursorPosition(gamezone.GetLength(0), i);
            System.Console.Write('┃');
        }
    }
    
}
