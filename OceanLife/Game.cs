namespace OceanLife;

public class Game
{
    Ocean oc = new Ocean();

    int iteration = Consts.OCEAN_ITERATION;

    public Game()
    {
        UI.DisplayCells(oc);

        do
        {
            


            UI.DisplayCells(oc);
            UI.DisplayStats(oc, iteration);
            oc.TakeAwayFeedAndReproduce();
            iteration--;
            
        } while (iteration == 0 || oc.NumPrey == 0 || oc.NumPredator == 0);
    }
}
