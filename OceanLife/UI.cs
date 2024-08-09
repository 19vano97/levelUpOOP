namespace OceanLife;

public class UI
{
    public static void DisplayBorder()
    {}

    public static void DisplayCells(Ocean oc)
    {
        for (int i = 0; i < oc.Cells.GetLength(0); i++)
        {
            for (int k = 0; k < oc.Cells.GetLength(1); k++)
            {
                Console.SetCursorPosition(i, k);
                System.Console.Write(oc.Cells[i, k].DefaultImage);
            }
        }
    }

    public static void DisplayStats(Ocean oc, int iterations)
    {
        System.Console.WriteLine("Preys: {0}", oc.NumPrey);
        System.Console.WriteLine("Predators: {0}", oc.NumPredator);
        System.Console.WriteLine("Obstacles: {0}", oc.NumObstacles);
        System.Console.WriteLine("Pred: {0}", iterations);
    }
}
