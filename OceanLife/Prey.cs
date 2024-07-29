namespace OceanLife;

public class Prey : Cell
{
    #region variables

        protected int _numPrey;


    #endregion

    #region default ctor

        public Prey(int x, int y) : base(x, y, Image.Fish)
        {
            _numPrey = (int)Consts.DEFAULT_NUM_PREY;
        }

        public Prey(int x, int y, Image im) : base(x, y, im)
        {
            _numPrey = (int)Consts.DEFAULT_NUM_PREY;
        }
        
    #endregion

    #region props

        public int Num
        {
            get
            {
                return _numPrey;
            }
            set
            {
                if (_numPrey < 0)
                {
                    return;
                }

                _numPrey = value;
            }
        }
        
    #endregion
}
