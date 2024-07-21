using Galaga;

internal class Program
{
    const int DELAY = 50;

    private static void Main(string[] args)
    {
        Console.Clear();

        GameLevel level = LevelDesign.GetLevelOfDifficulty(LevelDesign.ChooseLevelFromAList());

        Console.Clear();

        int score = 0;

        char[,] gamezone = GamezoneManipulations.InitGamezone();

        Spaceship[] allSpaceships = SpaceshipManipulation.InitSpaceshipArray(gamezone, level);
        Spaceship hero = allSpaceships[0];
        
        UI.SetDefaultPosition(gamezone);

        int x = UI.GetDefaultPosition(gamezone).x;
        int y = UI.GetDefaultPosition(gamezone).y;

        bool isRunning = true;

        // Start position
        hero.spaceshipCoodinates.x = x;
        hero.spaceshipCoodinates.y = y;

        Movements direction = Movements.None;

        Console.CursorVisible = false;

        ulong gameTime = 0;

        GameProperty currentGameProperties = new GameProperty()
        {
            gamezone = gamezone,
            allSpaceships = allSpaceships,
            gameTime = gameTime,
            isGameOver = isRunning,
            level = level,
            score = score
        };

        ConsoleKey key;

        do
        {
            hero = currentGameProperties.allSpaceships[0];

            #region SpaceshipMove

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey().Key;
    
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Movements.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Movements.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Movements.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Movements.Right;
                            break;
                        case ConsoleKey.Spacebar:
                            AttackBlusterUI.ShootByBluster(ref currentGameProperties, ref hero, false);
                            break;
                        case ConsoleKey.Escape:
                            currentGameProperties.isGameOver = false;
                            break;
                        default:
                            break;
                    }
                }
    
                if (gameTime % level.heroSpeed == 0L)
                {
                    switch (direction)
                    {       
                        case Movements.Up:
                            SpaceshipManipulation.MoveSpaceship(ref currentGameProperties, 
                                                                ref hero, ref x, ref y, direction);
                            break;
                        case Movements.Down:
                            SpaceshipManipulation.MoveSpaceship(ref currentGameProperties,
                                                                ref hero, ref x, ref y, direction);
                            break;
                        case Movements.Left:
                            SpaceshipManipulation.MoveSpaceship(ref currentGameProperties,
                                                                ref hero, ref x, ref y, direction);
                            break;
                        case Movements.Right:
                            SpaceshipManipulation.MoveSpaceship(ref currentGameProperties,
                                                                ref hero, ref x, ref y, direction);
                            break;
                        default:
                            break;
                    }
    
                }

            #endregion

            EnemyManipulation.GenerateAmountOfEnemiesOnStart(ref currentGameProperties);
            
            EnemyManipulation.MoveAndShootEnemies(ref currentGameProperties);

            UI.PrintScreenOfGamezone(currentGameProperties.gamezone);
            UI.PrintShortInfoAboutSpaceShip(currentGameProperties.gamezone, hero, currentGameProperties.score);
            
            Thread.Sleep(DELAY);

            currentGameProperties.gameTime +=2;

        } while (currentGameProperties.isGameOver);

        Console.CursorVisible = false;
    }
}