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
            _coord = new Coordinates(x, y);
            _defaultImage = Image.Cell;
        }

        public Cell(int x, int y, Image im)
        {
            _defaultImage = im;
        }

        public Cell(Coordinates coord) : this(coord.X, coord.Y)
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
