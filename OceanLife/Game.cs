namespace OceanLife;

public class Game
{
    public Game()
    {
        Ocean oc = new Ocean();

        // TODO: input num of iterations manually

        //def
        int iteration = 100;

        do
        {
            
            Process(ref oc);
            oc.Update();
            UI.DisplayCells(oc);
            UI.DisplayStats(oc, iteration);
            iteration--;

            Thread.Sleep(100);
            
        } while (iteration != 0);
        // } while (iteration != 0 | oc.NumPrey != 0 | oc.NumPredator != 0);
    }

    private void Process(ref Ocean oc)
    {
        for (int i = 0; i < oc.Cells.GetLength(0); i++)
        {
            for (int k = 0; k < oc.Cells.GetLength(1); k++)
            {
                if (oc.Cells[i, k] != null)
                {
                    oc.Cells[i, k].Process(ref oc);
                }
            }
        }

        oc.Update();
    }
}
