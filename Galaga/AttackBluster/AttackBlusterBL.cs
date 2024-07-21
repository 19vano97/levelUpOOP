namespace Galaga;

public class AttackBlusterBL
{
    const int DELAY_OF_KILLED_ENEMY = 100;

    public static void DamageSpaceship(ref GameProperty currentGameProperties, ref Spaceship attacker, 
                                                ref Spaceship victim)
    {
        if (attacker.bluster.coordinates.x == victim.spaceshipCoodinates.x 
                && attacker.bluster.coordinates.y == victim.spaceshipCoodinates.y)
        {
            victim.healthPoint = victim.healthPoint - attacker.bluster.damage;

            currentGameProperties.allSpaceships = SpaceshipManipulation.UpdateSpaceshipArray(ref currentGameProperties.allSpaceships, ref victim);

            if (victim.healthPoint <= 0)
            {
                GamezoneManipulations.DeletePosition(ref currentGameProperties.gamezone, victim.spaceshipCoodinates);

                Console.SetCursorPosition(victim.spaceshipCoodinates.x, victim.spaceshipCoodinates.y);
                Console.Write(AttackBlusterUI.GetEnemyDestroyed());

                Thread.Sleep(DELAY_OF_KILLED_ENEMY);

                Console.SetCursorPosition(victim.spaceshipCoodinates.x, victim.spaceshipCoodinates.y);
                Console.Write(' ');

                if (attacker.id == 0)
                {
                    currentGameProperties.score++;
                }
                else
                {
                    currentGameProperties.isGameOver = false;
                }

                currentGameProperties.allSpaceships = SpaceshipManipulation.DeleteSpaceshipFromArray(ref currentGameProperties.allSpaceships, victim);
            }
            else
            {
                currentGameProperties.gamezone = UI.PrintEnemy(ref currentGameProperties.gamezone, ref victim);
            }
        }
    }

    public static bool IsTargetUnderBlustShot(PositionOf blusterShotPosition, ref Spaceship[] allSpaceships)
    {
        for (int i = 0; i < allSpaceships.Length; i++)
        {
            if (allSpaceships[i].spaceshipCoodinates.x == blusterShotPosition.x 
                    && allSpaceships[i].spaceshipCoodinates.y == blusterShotPosition.y)
            {
                return true;
            }
        }

        return false;
    }

    public static Spaceship GetVictimOnShotLine(PositionOf blusterShotPosition, 
                                                ref Spaceship[] allSpaceships, 
                                                bool enemyShot = false)
    {       
        if (!enemyShot)
        {
            for (int i = 0; i < allSpaceships.Length; i++)
            {
                if (allSpaceships[i].spaceshipCoodinates.x == blusterShotPosition.x 
                    && allSpaceships[i].spaceshipCoodinates.y == blusterShotPosition.y)
                {
                    return allSpaceships[i];
                }
            }
        }
 
        return SpaceshipManipulation.FindHeroByCoordinates(allSpaceships);
    }

    public static void EnemyAutoShooting(ref GameProperty currentGameProperties, ref Spaceship enemy)
    {
        if (currentGameProperties.gameTime % currentGameProperties.level.enemyShotFrequensy == 0)
        {
            AttackBlusterUI.ShootByBluster(ref currentGameProperties, ref enemy, true);
        }
    }
}
