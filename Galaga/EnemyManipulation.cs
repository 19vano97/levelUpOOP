namespace Galaga;

public class EnemyManipulation
{
    public static void MoveAutomiticallyEnemy(ref GameProperty currentGameProperties, ref Spaceship enemy)
    {
        Movements directionInt = GetRandomStepOfDirectionForEnemy(currentGameProperties.gamezone, enemy);

        if (currentGameProperties.gameTime % currentGameProperties.level.enemySpeed == 0)
        {
            if (directionInt == Movements.Left)
            {
                SpaceshipManipulation.MoveSpaceship(ref currentGameProperties, ref enemy, ref enemy.spaceshipCoodinates.x, 
                                                                ref enemy.spaceshipCoodinates.y, directionInt);
            }
            
            if (directionInt == Movements.Right)
            {
                SpaceshipManipulation.MoveSpaceship(ref currentGameProperties, ref enemy, ref enemy.spaceshipCoodinates.x, 
                                                                ref enemy.spaceshipCoodinates.y, directionInt);
            }
    
            if (directionInt == Movements.Up)
            {
                SpaceshipManipulation.MoveSpaceship(ref currentGameProperties, ref enemy, ref enemy.spaceshipCoodinates.x, 
                                                                ref enemy.spaceshipCoodinates.y, directionInt);
            }
    
            if (directionInt == Movements.Down)
            {
                SpaceshipManipulation.MoveSpaceship(ref currentGameProperties, ref enemy, ref enemy.spaceshipCoodinates.x, 
                                                                ref enemy.spaceshipCoodinates.y, directionInt);
            }
        }
    }

    public static Movements GetRandomStepOfDirectionForEnemy(char[,] gamezone, Spaceship enemy)
    {
        Movements direction = (Movements)BL.GetRandomInt(1, Enum.GetValues(typeof(Movements)).Cast<int>().Max());
        
        if (direction.HasFlag(Movements.Left) && (enemy.spaceshipCoodinates.x - 1) <= 0)
        {
            Movements directionTryAgain = GetRandomStepOfDirectionForEnemy(gamezone, enemy);
            
            return directionTryAgain;
        }

        if (direction.HasFlag(Movements.Right) && enemy.spaceshipCoodinates.x >= gamezone.GetLength(0) - 1)
        {
            Movements directionTryAgain = GetRandomStepOfDirectionForEnemy(gamezone, enemy);
            
            return directionTryAgain;
        }

        if (direction.HasFlag(Movements.Up) && (enemy.spaceshipCoodinates.y - 1) <= 0)
        {
            Movements directionTryAgain = GetRandomStepOfDirectionForEnemy(gamezone, enemy);
            
            return directionTryAgain;
        }

        if (direction.HasFlag(Movements.Left) && (enemy.spaceshipCoodinates.y >= gamezone.GetLength(0) - 1))
        {
            Movements directionTryAgain = GetRandomStepOfDirectionForEnemy(gamezone, enemy);
            
            return directionTryAgain;
        }


        return direction;
    }

    public static void GenerateAmountOfEnemiesOnStart(ref GameProperty currentGameProperties)
    {
        if (GetAmountOfEnemies(currentGameProperties.allSpaceships) > currentGameProperties.level.maxEnemiesOnScreen 
            || GetAmountOfEnemies(currentGameProperties.allSpaceships) > 1)
        {
            return;
        }
       
        for (int i = 0; i < currentGameProperties.level.maxEnemiesOnScreen; i++)
        {
            Spaceship enemy = SpaceshipManipulation.InitEnemy(currentGameProperties.gamezone, currentGameProperties.level); 
            currentGameProperties.allSpaceships = SpaceshipManipulation.AddSpaceshipToArray(ref currentGameProperties.allSpaceships, ref enemy);
        }
    }

    public static void MoveAndShootEnemies(ref GameProperty currentGameProperties)
    {
        for (int i = 1; i < currentGameProperties.allSpaceships.Length; i++)
        {
            MoveAutomiticallyEnemy(ref currentGameProperties, ref currentGameProperties.allSpaceships[i]);
            AttackBlusterBL.EnemyAutoShooting(ref currentGameProperties, ref currentGameProperties.allSpaceships[i]);

            currentGameProperties.allSpaceships = SpaceshipManipulation.UpdateSpaceshipArray(ref currentGameProperties.allSpaceships, 
                                                                                                ref currentGameProperties.allSpaceships[i]);
        }
    }

    public static int GetAmountOfEnemies(Spaceship[] allSpaceships)
    {
        return allSpaceships.Length - 1;
    }
}
