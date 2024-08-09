namespace OceanLife;

public class Run
{
    Ocean oc = new Ocean();

    int iteration = Consts.OCEAN_ITERATION;

    public Run()
    {
        do
        {


            oc.TakeAwayFeedAndReproduce();
            iteration--;
            
        } while (iteration == 0 || oc.NumPrey == 0 || oc.NumPredator == 0);
    }
}
