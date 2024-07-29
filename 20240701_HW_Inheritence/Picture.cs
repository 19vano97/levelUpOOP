using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _20240701_HW_Inheritence;

public class Picture : Point, IGeometrical
{
    #region variables

        public const string DEFAULT_FILENAME = "untitled"; 
        private string _fileName;
        private Point[] _figures;

    #endregion
    

    #region default ctors

        public Picture() : base()
        {
            if (_fileName == null)
            {
                _fileName = DEFAULT_FILENAME;
            }

            _figures = [];
        }
        
        public Picture (params Point[] figures) : this ()
        {
            _figures = (Point[])figures.Clone();
        }
    
        public Picture (string fileName) : this()
        {
            _fileName = fileName;
        }
    
        public Picture(string fileName, params Point[] figures) : this (figures)
        {
            _fileName = fileName;
        }

    #endregion

    public string FileName
    {
        get
        {
            return _fileName;
        }
        set
        {
            if (_fileName == null || _fileName == string.Empty || _fileName.Length == 0)
            {
                return;
            }

            _fileName = value;
        }
    }

    public void Add(Point figureToAdd)
    {
        Array.Resize(ref _figures, _figures.Length + 1);
        _figures[_figures.Length - 1] = figureToAdd;
    }

    public void Add(params Point[] figureToAdd)
    {
        for (int i = 0; i < figureToAdd.Length; i++)
        {
            Array.Resize(ref _figures, _figures.Length + 1);
            _figures[_figures.Length - 1] = figureToAdd[i];
        }
    }

    public void Delete(Point figureToDelete)
    {
        int index = 0;

        for (int i = 0; i < _figures.Length; i++)
        {
            if (_figures[i].CoordX == figureToDelete.CoordX && _figures[i].CoordY == figureToDelete.CoordY)
            {
                index = i;
                break;
            }
        }

        for (int i = index; i < _figures.Length; i++)
        {
            _figures[i] = _figures[i + 1];
        }

        Array.Resize(ref _figures, _figures.Length - 1);
    }

    public Point this[int index]
    {
        get { return _figures[index]; }
        set { _figures[index] = value; }
    }

    public Point[] Points
    {
        get
        {
            return _figures;
        }
    }

    public override void Move(int x, int y)
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i].Move(x, y);
        }
    }

    public override void Resize(double index)
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i].Resize(index);
        }
    }

    public override void Rotate45()
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i].Rotate45();
        }
    }

    public override PicItem[] GetView()
    {
        int indexLength = 0;
        
        for (int i = 0; i < _figures.Length; i++)
        {
            indexLength += _figures[i].GetView().Length;
        }

        PicItem[] figuresView = new PicItem[indexLength];

        int indexCount = 0;

        int size = _figures.Length;

        for (int y = 0; y < size; y++)
        {
            for (int k = 0; k < _figures[y].GetView().Length; k++)
            {
                figuresView[indexCount] = new PicItem(_figures[y].GetView()[k]);
                indexCount++;
            }
        }

        return figuresView;
    }

    public double GetArea()
    {
        double area = 0d;

        for (int i = 0; i < _figures.Length; i++)
        {
            if (_figures[i] is IGeometrical)
            {
                area += ((IGeometrical)_figures[i]).GetArea();
            }
        }

        return area;
    }

    public int GetPerimeter()
    {
        int p = 0;

        for (int i = 0; i < _figures.Length; i++)
        {
            IGeometrical ig = _figures[i] as IGeometrical;

            if (ig != null)
            {
                p += ig.GetPerimeter();
            }
        }

        return p;
    }


}
