using System.Collections;

namespace OceanLife;

public class Ocean
{
    #region varaibles

        private Cell[,] _cells;
        private int _size;
        protected int _numPrey;
        protected int _numObstacles;
        protected int _numPredators;

    #endregion

    #region default ctors

        public Ocean()
        {
            _cells = new Cell[Consts.OCEAN_NUM_ROWS, Consts.OCEAN_NUM_COLS];
            _size = _cells.Length;
            _numPrey = Consts.DEFAULT_NUM_PREY;
            _numObstacles = Consts.DEFAULT_NUM_OBSTACLES;
            _numPredators = Consts.DEFAULT_NUM_PREDATORS;
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

        public int NumPrey
        {
            get
            {
                if (_numPrey < 0)
                {
                    return 0;
                }

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

        public int NumObstacles
        {
            get
            {
                if (_numObstacles < 0)
                {
                    return 0;
                }

                return _numObstacles;
            }
            set
            {
                if (_numObstacles < 0 || _numObstacles > _size)
                {
                    return;
                }

                _numObstacles = value;
            }
        }

        public int NumPredator
        {
            get
            {
                if (_numPredators < 0)
                {
                    return 0;
                }

                return _numPredators;
            }
            set
            {
                if (_numPredators < 0)
                {
                    return;
                }

                _numPrey = value;
            }
        }

    #endregion

    public void Init()

    public void TakeAwayFeedAndReproduce()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Prey)
                {
                    _cells[i, k].ReduceTTL();
                }

                if (_cells[i, k] is Predator)
                {
                    _cells[i, k].ReduceTTL();
                }
            }
        }
    }

    public void Update()
    {

    }

    public void AddPrey(int num)
    {

    }

    
}
