namespace Galaga;

public class LevelDesign
{
    public static GameLevelStructure GetLevelOfDifficulty(LevelEnums levelName = LevelEnums.Medium)
    {
        if (levelName == LevelEnums.Low)
        {
            GameLevelStructure level = new GameLevelStructure()
            {
                name = levelName,
                heroHealthpoints = 150,
                heroBlusterDamage = 100,
                heroSpeed = 2,
                enemyHealthpoints = 50,
                enemyBlusterDamage = 30,
                enemySpeed = 7,
                enemyShotFrequensy = 30,
                maxEnemiesOnScreen = 3
            };

            return level;
        }
        else if (levelName == LevelEnums.Hard)
        {
            GameLevelStructure level = new GameLevelStructure()
            {
                name = levelName,
                heroHealthpoints = 50,
                heroBlusterDamage = 50,
                heroSpeed = 4,
                enemyHealthpoints = 75,
                enemyBlusterDamage = 25,
                enemySpeed = 4,
                enemyShotFrequensy = 15,
                maxEnemiesOnScreen = 5
            };

            return level;
        }
        else
        {
            GameLevelStructure level = new GameLevelStructure()
            {
                name = levelName,
                heroHealthpoints = 100,
                heroBlusterDamage = 75,
                heroSpeed = 2,
                enemyHealthpoints = 75,
                enemyBlusterDamage = 25,
                enemySpeed = 5,
                enemyShotFrequensy = 10,
                maxEnemiesOnScreen = 4
            };

            return level;
        }

    }

    public static LevelEnums ChooseLevelFromAList()
    {
        for (int i = 1; i <= Enum.GetValues(typeof(LevelEnums)).Cast<int>().Max(); i++)
        {
            if (i == Enum.GetValues(typeof(LevelEnums)).Cast<int>().Max())
            {
                System.Console.Write("{0}. {1}", i, (LevelEnums)i);
                break;
            }

            System.Console.Write("{0}. {1}, ", i, (LevelEnums)i);
        }

        System.Console.WriteLine();

        int value = UI.GetIntInput("level");

        return (LevelEnums)value;
    }
}
