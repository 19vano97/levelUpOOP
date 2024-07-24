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

    // public override double GetArea()
    // {
    //     int[] sides = FindSidesOfQuadraliteral();

    //     int p = GetPerimeter() / 2;

    //     double d = 1d;

    //     for (int i = 0; i < sides.Length; i++)
    //     {
    //         d *= p - sides[i];
    //     }
      
    //     return Math.Sqrt(d);
    // }

    // public override int GetPerimeter()
    // {
    //     int[] sides = FindSidesOfQuadraliteral();

    //     int p = 0;

    //     for (int i = 0; i < sides.Length; i++)
    //     {
    //         p += sides[i];
    //     }

    //     return p;
    // }

    // private int[] FindSidesOfQuadraliteral()
    // {
    //     Point[] points = CalculateMaxPoints();

    //     int[] sides = new int[4];

    //     for (int i = 0; i < points.Length; i++)
    //     {
    //         if (i < points.Length - 1)
    //         {
    //             sides[i] = (int)Math.Sqrt(Math.Pow(points[i + 1].CoordX - points[i].CoordX, 2) + Math.Pow(points[i + 1].CoordY - points[i].CoordY, 2));
    //         }
    //         else
    //         {
    //             sides[i] = (int)Math.Sqrt(Math.Pow(points[i].CoordX - points[0].CoordX, 2) + Math.Pow(points[i].CoordY - points[0].CoordY, 2));
    //         }
    //     }

    //     return sides;
    // }

    // private Point[] CalculateMaxPoints()
    // {
    //     Point[] points = new Point[4];

    //     for (int i = 0; i < points.Length; i++)
    //     {
    //         points[i] = new Point(155, 22);
    //         // points[i] = new Point(Console.WindowWidth, Console.WindowHeight);
    //     }

    //     for (int i = 0; i < points.Length; i++)
    //     {
    //         for (int k = 0; k < _figures.Length; k++)
    //         {
    //             if (_figures[k] is Quadrilateral)
    //             {
    //                 for (int m = 0; m < _figures[k].Points.Length; m++)
    //                 {
    //                     if (points[i].CoordX > _figures[k].Points[m].CoordX && points[i].CoordY < _figures[k].Points[m].CoordY)   //point[0] TOP Left
    //                     {
    //                         points[i].UpdatePoint(_figures[k]);
    //                         break;
    //                     }
                        
    //                     if (points[i].CoordX < _figures[k].CoordX && points[i].CoordY < _figures[k].CoordY)   //point[1] TOP right
    //                     {
    //                         points[i].UpdatePoint(_figures[k]);
    //                         break;
    //                     }
        
    //                     if (points[i].CoordX > _figures[k].CoordX && points[i].CoordY > _figures[k].CoordY)   //point[2] bottom left
    //                     {
    //                         points[i].UpdatePoint(_figures[k]);
    //                         break;
    //                     }
        
    //                     if (points[i].CoordX < _figures[k].CoordX && points[i].CoordY > _figures[k].CoordY)   //point[3] bottom right
    //                     {
    //                         points[i].UpdatePoint(_figures[k]);
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //     }

    //     return points;
    // }

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
