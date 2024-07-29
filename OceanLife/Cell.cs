namespace OceanLife;

public class Cell
{
    #region variables

        protected Coordinates _coord;
        protected Image _defaultImage; 
        protected int _timeToReproduce;

    #endregion

    #region default ctors

        public Cell(int x, int y)
        {
            _coord.X = x;
            _coord.Y = y;
            _timeToReproduce = (int)Consts.DEFAULT_TIME_TO_REPRODUCE;

            if (_defaultImage == null)
            {
                _defaultImage = Image.Cell;
            }
        }

        public Cell(int x, int y, Image im) : this(x, y)
        {
            _defaultImage = im;
        }

    #endregion

    #region prop

        public Coordinates Coord
        {
            get
            {
                return _coord;
            }
            set
            {
                _coord = value;
            }
        }

        public Image DefaultImage
        {
            get
            {
                return _defaultImage;
            }
        }

    #endregion
}
