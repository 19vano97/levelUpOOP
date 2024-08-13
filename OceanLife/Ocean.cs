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
            _cells = new Cell[Consts.OCEAN_NUM_COLS, Consts.OCEAN_NUM_ROWS];
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

        public Cell this[Coordinates coord]
        {
            get => _cells[coord.X, coord.Y];
            set => _cells[coord.X, coord.Y] = value;
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
                if (_cells[i, k] is Predator)
                {
                    _cells[i, k].ReduceTTL();
                }

                if (_cells[i, k] is Prey)
                {
                    _cells[i, k].ReduceTTL();
                }

                if (_numPrey == -1)
                {
                    string s = ("_numPrey == -1   and cycle is", i, k).ToString();
                    throw new ArithmeticException(s);
                }
            }
        }

        Update();

        SyncNumbersOfFish();
    }

    public void Update()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Predator && _cells[i, k].GetTime() == 0)
                {
                    _cells[i, k] = null!;
                    _numPredators--;
                }

                if (_cells[i, k] is Prey && _cells[i, k].GetTime() == 0)
                {
                    _cells[i, k] = null!;
                    _numPrey--;
                }
            }
        }

        CheckCellsPositions();
    }

    public void SyncNumbersOfFish()
    {
        int numPrey = 0;
        int numPredator = 0;

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Predator)
                {
                    numPredator++;
                }
                else if (_cells[i, k] is Prey)
                {
                    numPrey++;
                }
            }
        }

        if (_numPrey != numPrey)
        {
            string s = ("_numPrey {0} != numPrey {1}", _numPrey, numPrey).ToString();
            throw new ArithmeticException(s);
        }

        if (_numPredators != numPredator)
        {
            string s = ("_numPredators {0} != numPredator {1}", _numPredators, numPredator).ToString();
            throw new ArithmeticException(s);
        }
    }

    #region Add

    // TODO: add try catch

        public void AddPrey(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {
                _numPrey += num;
        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Prey(coord);
                    }
                }
            }
        }
    
        public void AddPrey()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Prey(coord);
    
                    _numPrey++;
                }
            }
        }
    
        public void AddPredator(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {
                _numPredators += num;
        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Predator(coord);
                    }
                }
            }
        }
    
        public void AddPredator()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Predator(coord);
    
                    _numPredators++;
                }
            }
        }
    
        public void AddObstacles(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {
                _numPrey += num;
        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Obstacle(coord);
                    }
                }
            }
        }
    
        public void AddObstacles()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Obstacle(coord);
    
                    _numObstacles++;
                }
            }
        }
    
    #endregion

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

    private bool IsFullCells()
    {
        if ((_numObstacles + _numPredators + _numPrey) >= _size)
        {
            return true;
        }

        return false;
    }

    private void CheckCellsPositions()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] != null && (i != _cells[i, k].Coord.X || k != _cells[i, k].Coord.Y))
                {
                    string s = ("Indexes are not equal to coords i = ", i, "k = ", k, 
                        "Coord.X = ", _cells[i, k].Coord.X, "Coord.Y = ", _cells[i, k].Coord.Y). ToString();
                    throw new Exception(s);
                }
            }
        }
    }

    #region GetCellInfo

        public Movement GetEmptyNeighbor(Cell c)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;
    
            Movement[] movements = new Movement[0];
    
            if (_cells[x, y + 1] == null)
            {
                AddMovementsArray(ref movements, Movement.Up);
            }
    
            if (_cells[x, y - 1] == null)
            {
                AddMovementsArray(ref movements, Movement.Down);
            }
    
            if (_cells[x + 1, y] == null)
            {
                AddMovementsArray(ref movements, Movement.Right);
            }
    
            if (_cells[x - 1, y] == null)
            {
                AddMovementsArray(ref movements, Movement.Left);
            }
    
            if (movements.Length == 0)
            {
                return Movement.None;
            }
    
            if (movements.Length == 1)
            {
                return movements[0];
            }
    
            int index = BL.GetRandomInt(0, movements.Length - 1);
    
            return movements[index];
        }
    
        private void AddMovementsArray(ref Movement[] movements, Movement m)
        {
            Array.Resize(ref movements, movements.Length);
    
            movements[movements.Length] = m;
        }

        private Coordinates GetCoordToMove(Cell c, Movement direction)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;

            if (direction == Movement.Up)
            {
                return new Coordinates(x, y + 1);
            }

            if (direction == Movement.Down)
            {
                return new Coordinates(x, y - 1);
            }

            if (direction == Movement.Right)
            {
                return new Coordinates(x + 1, y);
            }

            if (direction == Movement.Left)
            {
                return new Coordinates(x - 1, y);
            }

            return new Coordinates(x, y);
        } 

        public Movement GetPreyNeighbor(Cell c)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;
    
            Movement[] movements = new Movement[0];
    
            if (_cells[x, y + 1] is Prey && _cells[x, y + 1] is not Predator)
            {
                AddMovementsArray(ref movements, Movement.Up);
            }
    
            if (_cells[x, y - 1] is Prey && _cells[x, y + 1] is not Predator)
            {
                AddMovementsArray(ref movements, Movement.Down);
            }
    
            if (_cells[x + 1, y] is Prey && _cells[x + 1, y] is not Predator)
            {
                AddMovementsArray(ref movements, Movement.Right);
            }
    
            if (_cells[x - 1, y] is Prey && _cells[x - 1, y] is not Predator)
            {
                AddMovementsArray(ref movements, Movement.Left);
            }
    
            if (movements.Length == 0)
            {
                return Movement.None;
            }
    
            if (movements.Length == 1)
            {
                return movements[0];
            }
    
            int index = BL.GetRandomInt(0, movements.Length - 1);
    
            return movements[index];
        }

        public Cell GetCellAt(Coordinates coord) => _cells[coord.X, coord.Y];

        public void AssignCellAt(Coordinates coord, Cell c)
        {
            _cells[coord.X, coord.Y] = c;
        }

    #endregion
}
