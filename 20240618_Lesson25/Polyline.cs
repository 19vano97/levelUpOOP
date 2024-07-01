using _20240610_IncapsulationDemo;
using System;
using System.Runtime.InteropServices;

namespace _20240509_StructsDemo
{
    // value type
    public struct Polyline
    {
        public const int DEFAULT_CAPACITY = 5;

        #region ---=== private data ===---

        private Point[] _points;
        private int _size;

        #endregion

        public Polyline(int capacity = Polyline.DEFAULT_CAPACITY)
        {
            _size = 0;
            _points = new Point[capacity];
        }

        public Polyline(Point p1, Point p2)
        {
            _size = 2;
            _points = new Point[]
            {
                p1,
                p2
            };
        }

        public Polyline(params Point[] points)
        {
            int capacity = points.Length;
            if (Polyline.DEFAULT_CAPACITY > capacity)
            {
                capacity = Polyline.DEFAULT_CAPACITY;
            }

            _size = 0;
            _points = new Point[capacity];

            // this - посилання на створюєму змінну ламаної лінії  
            for (int i = 0; i < points.Length; i++)
            {
                AddPoint(points[i]);
            }
        }

        //public int GetCapacity()
        //{
        //    return _points.Length;
        //}

        //public int GetSize()
        //{
        //    return _size;
        //}

        #region Properties

        public int Capacity
        { 
            get 
            { 
                return _points.Length; 
            } 
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        #endregion

        #region ---  Polyline CRUD-operations  ---- 


        
        // Create
        public void AddPoint(Point p)
        {
            //if (_size >= GetCapacity())
            // if (Size >= Capacity)
            // if (_size >= _points.Length)
            if (_size >= Capacity)
            {
                // ToDo: set new size
                Array.Resize(ref _points, Capacity * 2);
            }

            _points[_size++] = p;
        }

        public Point DelelePoint(int position)
        {
            Point deleted = _points[position];

            for (int i = position; i < _size - 1; i++)
            {
                _points[i] = _points[i + 1];
            }

            --_size;

            return deleted;
        }

        public bool TryDelelePoint(Point p)
        {
            int pos = FindPosition(p);

            bool ok = pos != -1;

            if (!ok)
            {
                return ok;
            }

            DelelePoint(pos);

            return ok;
        }

        // Read
        public int FindPosition(Point p)
        {
            int index = -1;

            for (int i = 0; i < _size; i++)
            {
                //if (_points[i].GetX() == p.GetX() && _points[i].GetY() == p.GetY())
                if (_points[i].X == p.X && _points[i].Y == p.Y)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public Point GetPoint(int index)
        {
            if (index < 0 || index >= _size)
            {
                // !!! error
            }

            return _points[index];
        }

        // Update

        public void SetPoint(int index, Point p)
        {
            if (index < 0 || index >= _size)
            {
                // !!! error
            }

            _points[index] = p;
        }

        public bool UpdatePoint(Point source, Point destination)
        {
            int pos = FindPosition(source);

            bool ok = pos != -1;

            if (!ok)
            {
                return ok;
            }

            _points[pos] = destination;

            return ok;
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i].Move(dx, dy);
            }
        }

        #endregion
    
        #region Indexator

        private bool IsValidPosition(int position)
        {
            return (position >= 0) && (position < _size);
        }
            
        //indexer
        public Point this[int position]
        {
            get 
            {
                if (!IsValidPosition(position))
                {
                    //error
                }

                return _points[position];
            }
            set 
            {
                if (!IsValidPosition(position))
                {
                    //error
                }
            }
        }

        public bool this[Point p]
        {
            get 
            {
                int pos = FindPosition(p);

                return pos!= -1;
            }
        }


        public bool this[int x, int y]
        {
            get 
            {
                int pos = FindPosition(new Point(x, y));

                return this[new Point(x, y)]; //call -> public bool this[Point p]
            }
        }

        #endregion
    }
}
