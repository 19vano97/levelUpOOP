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
            
            
            oc.Update();
            UI.DisplayCells(oc);
            UI.DisplayStats(oc, iteration);
            iteration--;

            Thread.Sleep(100);
            
        } while (iteration != 0);
        // } while (iteration != 0 | oc.NumPrey != 0 | oc.NumPredator != 0);
    }
}
