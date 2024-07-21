namespace Galaga;

public class SpaceshipManipulation
{
    public static Spaceship[] InitSpaceshipArray(char[,] gamezone, GameLevel level)
    {
        Spaceship[] spaceships = new Spaceship[1];
        spaceships[0] = InitHero(gamezone, level);

        return spaceships;
    }

    public static Spaceship[] AddSpaceshipToArray(ref Spaceship[] allSpaceships, 
                                                                ref Spaceship spaceship)
    {
        Array.Resize(ref allSpaceships, allSpaceships.Length + 1);
        allSpaceships[allSpaceships.Length - 1] = spaceship;
        spaceship.id = allSpaceships.Length - 1;

        allSpaceships = UpdateSpaceshipArray(ref allSpaceships, ref spaceship);

        return allSpaceships;
    }

    public static Spaceship[] UpdateSpaceshipArray(ref Spaceship[] allSpaceships, 
                                                                ref Spaceship spaceship)
    {
        allSpaceships[spaceship.id] = spaceship;

        return allSpaceships;
    }

    public static Spaceship[] DeleteSpaceshipFromArray(ref Spaceship[] allSpaceships, 
                                                                    Spaceship spaceshipToDelete)
    {
        for (int i = spaceshipToDelete.id; i < allSpaceships.Length - 1; i++)
        {
            allSpaceships[i] = allSpaceships[i + 1];
            allSpaceships[i].id = allSpaceships[i].id - 1;
        }

        Array.Resize(ref allSpaceships, allSpaceships.Length - 1);

        return allSpaceships;
    }
    
    public static Spaceship InitHero(char[,] gamezone, GameLevel level)
    {
        Spaceship hero = new Spaceship()
        {
            id = 0,
            symbol = UI.GetHeroSymbol(),
            healthPoint = level.heroHealthpoints,
            bluster = InitBlusterProperties(level.heroBlusterDamage, AttackBlusterUI.GetHeroBlusterShot(), level.heroSpeed),
            spaceshipCoodinates = UI.GetDefaultPosition(gamezone),
            spaceshipSpeed = 2
        };

        return hero;
    }

    public static BlusterProperty InitBlusterProperties(int damage = 100, char symbolOfShot = '|', ulong speed = 3)
    {
        BlusterProperty bluster = new BlusterProperty()
        {
            damage = damage,
            symbolOfShot = symbolOfShot,
            bluserSpeed = speed
        };

        return bluster;
    }

    public static Spaceship InitEnemy(char[,] gamezone, GameLevel level)
    {
        Spaceship enemy = new Spaceship()
        {
            id = 0,
            symbol = UI.GetEnemySymbol(),
            healthPoint = level.enemyHealthpoints,
            bluster = InitBlusterProperties(level.enemyBlusterDamage, AttackBlusterUI.GetEnemyBlusterShot(), level.enemySpeed),
            spaceshipCoodinates= LocateEnemy(gamezone)
        };

        return enemy;
    }

    public static Spaceship FindHeroByCoordinates(Spaceship[] allSpaceships)
    {
        Spaceship hero = new Spaceship();

        for (int i = 0; i < allSpaceships.Length; i++)
        {
            if (allSpaceships[i].symbol == UI.GetHeroSymbol())
            {
                hero = allSpaceships[i];
            }
        }

        return hero;
    }

    public static PositionOf LocateEnemy(char[,] gamezone)
    {
        int xLocateEnemy = BL.GetRandomInt(0, gamezone.GetLength(0));
        //int xLocateEnemy = gamezone.GetLength(0) / 2;

        PositionOf coordinates = new PositionOf()
        {
            x = xLocateEnemy,
            y = 2
        };

        return coordinates;
    }

    public static void MoveSpaceship(ref GameProperty currentGameProperties, ref Spaceship spaceship, ref int x, ref int y, 
                                            Movements direction)
    {
        Console.CursorVisible = false;

        Console.SetCursorPosition(spaceship.spaceshipCoodinates.x, spaceship.spaceshipCoodinates.y);
        System.Console.Write(' ');

        PositionOf oldPosition = new PositionOf()
        {
            x = spaceship.spaceshipCoodinates.x,
            y = spaceship.spaceshipCoodinates.y
        };

        if (direction.HasFlag(Movements.Up))
        {
            if (y - 1 < 1)
            {
                spaceship.spaceshipCoodinates.y = y;
            }
            else
            {
                y--;
                spaceship.spaceshipCoodinates.y = y;
            }
        }
        
        if (direction.HasFlag(Movements.Down))
        {
            if (y + 1 > currentGameProperties.gamezone.GetLength(1))
            {
                spaceship.spaceshipCoodinates.y = y;
            }
            else
            {
                y++;
                spaceship.spaceshipCoodinates.y = y;
            }
        }
        
        if (direction.HasFlag(Movements.Left))
        {
            if (x - 1 < 1)
            {
                spaceship.spaceshipCoodinates.x = x;
            }
            else
            {
                x--;
                spaceship.spaceshipCoodinates.x = x;
            }
        }
        
        if (direction.HasFlag(Movements.Right))
        {
            if (x + 1 > currentGameProperties.gamezone.GetLength(0))
            {
                spaceship.spaceshipCoodinates.x = x;
            }
            else
            {
                x++;
                spaceship.spaceshipCoodinates.x = x;
            }
        }
        
        GamezoneManipulations.UpdatePositionOnGamezone(ref currentGameProperties.gamezone, spaceship, oldPosition, false);
        currentGameProperties.allSpaceships = UpdateSpaceshipArray(ref currentGameProperties.allSpaceships, ref spaceship);

        Console.SetCursorPosition(spaceship.spaceshipCoodinates.x, spaceship.spaceshipCoodinates.y);
        System.Console.Write(spaceship.symbol);
    }

}
