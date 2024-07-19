namespace _20240701_HW_Inheritence;

public abstract class Quadrilateral : Point
{
    #region data
        protected int _length;
        protected const int AMOUNT_OF_ANGLES = 4;

    #endregion

    #region default ctors

        public Quadrilateral(int x, int y, int length) : base(x, y)
        {
            _length = length;
        }

    #endregion

    public int Length 
    { 
        get
        {
            if (_length < 0)
            {
                return 0;
            }

            return _length;
        } 
        
        set
        {
            if (_length < 0)
            {
                return;
            }

            _length = value;
        } 
    }

    protected abstract void CalculatePoints(int x, int y, int length, int height = 0);

}
