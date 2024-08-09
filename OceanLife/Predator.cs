namespace OceanLife;

public class Predator : Prey
{
    #region varaibles

        protected int _timeToFeed;

    #endregion

    #region default ctors

        public Predator(int x, int y) : base(x, y, Image.Shark)
        {
            _timeToFeed = Consts.DEFAULT_TIME_TO_FEED;
        }

    #endregion

    #region prop

        public int TimeToFeed
        {
            get
            {
                if (_timeToFeed < 0)
                {
                    return 0;
                }

                return _timeToFeed;
            }
            set
            {
                if (_timeToFeed < 0)
                {
                    return;
                }
                
                _timeToFeed = value;
            }
        }

    #endregion

    public override void ReduceTTL() => _timeToFeed -= 1;
}
