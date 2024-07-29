namespace OceanLife;

public class Ocean
{
    #region varaibles

        private const int _NUM_ROWS = 25;
        private const int _NUM_COLS = 70;
        private Cell[,] _cells;
        private int _size;

    #endregion

    #region default ctors

        public Ocean()
        {
            _cells = new Cell[_NUM_ROWS, _NUM_COLS];
            _size = _cells.Length;
        }

    #endregion

    #region props

        public Cell[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Cell this[int indexX, int indexY]
        {
            get { return _cells[indexX, indexY]; }
            set { _cells[indexX, indexY] = value; }
        }
        
    #endregion

    
}
