namespace Galaga;

public class GamezoneManipulations
{
    public static char[,] InitGamezone()
    {
        int x = Console.WindowWidth;
        int y = Console.WindowHeight - 5;
        // int x = 155;
        // int y = 22;

        char[,] gamezone = new char[x, y];

        return gamezone;
    }

    public static void UpdatePositionOnGamezone(ref char[,] gamezone, Spaceship spaceship, 
                                                   Position oldPosition, bool attack = false)
    {
        if (attack == false)
        {
            if (spaceship.spaceshipCoodinates.x < 0 || spaceship.spaceshipCoodinates.x > gamezone.GetLength(0) - 1 
                || spaceship.spaceshipCoodinates.y < 0 || spaceship.spaceshipCoodinates.y > gamezone.GetLength(1) - 1)
            {
                return;
            }
            else
            {
                gamezone[spaceship.spaceshipCoodinates.x, spaceship.spaceshipCoodinates.y] = spaceship.symbol;  
            }
        }
        else
        {
            gamezone[spaceship.bluster.coordinates.x, spaceship.bluster.coordinates.y] = spaceship.bluster.symbolOfShot;
        }

        DeletePosition(ref gamezone, oldPosition);
    }

    public static void DeletePosition(ref char[,] gamezone, Position oldPosition)
    {
        if (oldPosition.x < 0 || oldPosition.x > gamezone.GetLength(0) - 1 
                || oldPosition.y < 0 || oldPosition.y > gamezone.GetLength(1) - 1)
        {
            return;
        }
        else
        {
            gamezone[oldPosition.x, oldPosition.y] = '\0';
        }
    }


}
