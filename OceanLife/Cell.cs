namespace OceanLife;

public abstract class Cell
{
    #region variables

        protected Coordinates _coord;
        protected Image _defaultImage; 

    #endregion

    #region default ctors

        public Cell(int x, int y)
        {
            _coord.X = x;
            _coord.Y = y;

            if (_defaultImage == null)
            {
                _defaultImage = Image.Cell;
            }
        }

        public Cell(int x, int y, Image im) : this(x, y)
        {
            _defaultImage = im;
        }

        public Cell() : this(0, 0)
        {}

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

    public abstract void ReduceTTL();

}
