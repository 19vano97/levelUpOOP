namespace Galaga;

public class Menu
{
    public static void ShowMenu(LevelEnums levelChoise = LevelEnums.Medium)
    {
        Console.Clear();

        int x = Console.WindowWidth / 2 - 5;
        int y = Console.WindowHeight / 2 - 1;

        System.Console.WriteLine("N. New game");
        System.Console.WriteLine("L. Choose leve;");
        System.Console.WriteLine("E. Exit");

        Console.SetCursorPosition(x - 2, y);
        System.Console.WriteLine("Your choice: ");
    
        bool isRunning = true;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.SetCursorPosition(x - 2, y + 10);
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.N:
                    // Run.RunGame(isRunning, LevelDesign.GetLevelOfDifficulty(levelChoise));                    
                    break;
                case ConsoleKey.L:
                    levelChoise = LevelDesign.ChooseLevelFromAList();
                    ShowMenu(levelChoise);
                    break;
                case ConsoleKey.E:
                    case ConsoleKey.Escape:
                        isRunning = false;
                        // Run.RunGame(isRunning, LevelDesign.GetLevelOfDifficulty(levelChoise));
                    break;
                default:
                    break;
            }

        } while (isRunning);

        Console.CursorVisible = false;

    }
}
