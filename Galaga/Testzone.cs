namespace Galaga;

public class Testzone
{
    public static void PrintSpaceShipArray(Spaceship[] allSpaceships)
    {
        System.Console.WriteLine();

        for (int i = 0; i < allSpaceships.Length; i++)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("id: {0}", allSpaceships[i].id);
            System.Console.WriteLine("symbol: {0}", allSpaceships[i].symbol);
            System.Console.WriteLine("health points: {0}", allSpaceships[i].healthPoint);
            System.Console.WriteLine("damage points: {0}", allSpaceships[i].bluster.damage);
            System.Console.WriteLine("position: {0}, {1}", allSpaceships[i].spaceshipCoodinates.x, allSpaceships[i].spaceshipCoodinates.y);            
        }
    }

    public static int PrintAmountOfHero(char[,] gamezone, Spaceship hero)
    {
        int value = 0;

        for (int i = 0; i < gamezone.GetLength(0); i++)
        {
            for (int j = 0; j < gamezone.GetLength(1); j++)
            {
                if (gamezone[i, j] == hero.symbol)
                {
                    value++;
                }
            }
        }

        return value;
    }
}
