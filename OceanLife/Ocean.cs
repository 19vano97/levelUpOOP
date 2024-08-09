using System.Collections;
using System.Runtime.CompilerServices;

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

            Init();
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
            get => _cells[indexX, indexY];
            set => _cells[indexX, indexY] = value;
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
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                _cells[i, k] = new Cell(i, k);
            }
        }
        
        for (int i = 0; i < _numPrey; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Prey(coord);
        }

        for (int i = 0; i < _numPredators; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Predator(coord);
        }

        for (int i = 0; i < _numObstacles; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Obstacle(coord);
        }
    }

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
        _numPrey += num;

        for (int i = 0; i < num; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Prey(coord);
        }
    }

    public void AddPredator(int num)
    {
        _numPrey += num;

        for (int i = 0; i < num; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Predator(coord);
        }
    }

    public void AddObstacles(int num)
    {
        _numPrey += num;

        for (int i = 0; i < num; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Obstacle(coord);
        }
    }

    private Coordinates GetRandomCoordinate()
    {
        Coordinates coord = new Coordinates();
        
        coord.X = BL.GetRandomInt(1, _cells.GetLength(0));
        coord.Y = BL.GetRandomInt(1, _cells.GetLength(1));

        if (!IsEmptyCell(coord))
        {
            return GetRandomCoordinate();
        }

        return coord;
    }

    private bool IsEmptyCell(Coordinates coord)
    {
        if (_cells[coord.X, coord.Y] is Prey 
            || _cells[coord.X, coord.Y] is Predator 
            || _cells[coord.X, coord.Y] is Obstacle)
        {
            return false;
        }

        return true;
    }

    
}
