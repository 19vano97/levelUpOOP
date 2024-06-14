using System.Security.Cryptography.X509Certificates;

namespace Galaga;

public class AttackBlusterUI
{
    public static void MoveBlusterShot(ref char[,] gamezone, ref Spaceship attacker, bool isEnemyShot)
    {
        int x = attacker.bluster.coordinates.x;
        int y = attacker.bluster.coordinates.y;

        Position oldShotPosition = new Position()
        {
            x = x,
            y = y
        };

        if (!isEnemyShot)
        {
            y--;
            attacker.bluster.coordinates.x = x;
            attacker.bluster.coordinates.y = y;
        }
        else
        {
            y++;
            attacker.bluster.coordinates.x = x;
            attacker.bluster.coordinates.y = y;
        }

        if (attacker.bluster.coordinates.y < 0 || attacker.bluster.coordinates.y > gamezone.GetLength(1) - 1)
        {
            attacker.bluster.coordinates.y = oldShotPosition.y;
            return;
        }

        Console.SetCursorPosition(attacker.bluster.coordinates.x, attacker.bluster.coordinates.y);
        System.Console.Write(attacker.bluster.symbolOfShot);

        GamezoneManipulations.UpdatePositionOnGamezone(ref gamezone, attacker, oldShotPosition, true);
    }

    public static void ShootByBluster(ref GameProperty currentGameProperties, ref Spaceship attacker, 
                                        bool isEnemyShot)
    {
        if (!isEnemyShot)
        {
            for (int i = attacker.spaceshipCoodinates.y - 1; i > 0; i--)
            {
                attacker.bluster.coordinates.x = attacker.spaceshipCoodinates.x;
                attacker.bluster.coordinates.y = i;
    
                MoveBlusterShot(ref currentGameProperties.gamezone, ref attacker, isEnemyShot);
    
                if (AttackBlusterBL.IsTargetUnderBlustShot(attacker.bluster.coordinates, 
                                                            ref currentGameProperties.allSpaceships))
                {
                    Spaceship victim = AttackBlusterBL.GetVictimOnShotLine(attacker.bluster.coordinates, 
                                                                            ref currentGameProperties.allSpaceships, 
                                                                            isEnemyShot);
                    
                    
                    
                    AttackBlusterBL.DamageSpaceship(ref currentGameProperties, ref attacker, ref victim);
                    break;
                }
            }

            for (int i = attacker.spaceshipCoodinates.y - 1; i >= 0; i--)
            {
                Thread.Sleep(2);

                Console.SetCursorPosition(attacker.bluster.coordinates.x, i);
                System.Console.Write(' ');
            }

        }
        else
        {
            for (int i = attacker.spaceshipCoodinates.y + 1; i < currentGameProperties.gamezone.GetLength(1); i++)
            {
                attacker.bluster.coordinates.x = attacker.spaceshipCoodinates.x;
                attacker.bluster.coordinates.y = i;
    
                MoveBlusterShot(ref currentGameProperties.gamezone, ref attacker, isEnemyShot);
    
                if (AttackBlusterBL.IsTargetUnderBlustShot(attacker.bluster.coordinates, ref currentGameProperties.allSpaceships))
                {
                    Spaceship victim = AttackBlusterBL.GetVictimOnShotLine(attacker.bluster.coordinates, 
                                                                            ref currentGameProperties.allSpaceships, isEnemyShot);

                    
                    AttackBlusterBL.DamageSpaceship(ref currentGameProperties, ref attacker, ref victim);
                    break;
                }
            }

            for (int i = attacker.spaceshipCoodinates.y + 1; i < currentGameProperties.gamezone.GetLength(1); i++)
            {
                Thread.Sleep(2);
                
                Console.SetCursorPosition(attacker.bluster.coordinates.x, i);
                System.Console.Write(' ');
            }
        }
    }

    public static char GetHeroBlusterShot()
    {
        return '\u2225';
    }

    public static char GetEnemyBlusterShot()
    {
        return '|';
    }

    public static char GetEnemyDestroyed()
    {
        return '\u2600';
    }
}
