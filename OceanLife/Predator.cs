namespace OceanLife;

public class Predator : Prey
{
    #region varaibles
    
        protected int _numPredators;
        protected int _timeToFeed;

    #endregion

    #region default ctors

        public Predator(int x, int y) : base(x, y, Image.Shark)
        {
            _numPredators = (int)Consts.DEFAULT_NUM_PREDATORS;
            _timeToFeed = (int)Consts.DEFAULT_TIME_TO_FEED;
        }
        
    #endregion

    #region prop
        
    #endregion
}
