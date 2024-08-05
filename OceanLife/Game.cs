namespace OceanLife;

public class Game
{
    Ocean oc = new Ocean();

    int iteration = Consts.OCEAN_ITERATION;

    public Game()
    {
        do
        {


            oc.TakeAwayFeedAndReproduce();
            iteration--;
            
        } while (iteration == 0 || oc.NumPrey == 0 || oc.NumPredator == 0);
    }
}
