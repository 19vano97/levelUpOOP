using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _20240701_HW_Inheritence;

public class Picture
{
    private const string DEFAULT_FILENAME = "untitled"; 
    private string _fileName;
    // protected Figure[] _figures;
    private Point[] _figures;
    

    public Picture (params Point[] figures)
    {
        _figures = (Point[])figures.Clone();
        _fileName = DEFAULT_FILENAME;
    }

    public Picture (string fileName) : this()
    {
        _fileName = fileName;
    }

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

    // public void AddFigure(Rectangle rectangleToAdd)
    // {
    //     Figure figureToAdd = new Figure(rectangleToAdd);

    //     Add(figureToAdd);
    // }

    // public void AddFigure(Square SquareToAdd)
    // {
    //     Figure figureToAdd = new Figure(SquareToAdd);

    //     Add(figureToAdd);
    // }

    // public void AddFigure(Circle circleToAdd)
    // {
    //     Figure figureToAdd = new Figure(circleToAdd);

    //     Add(figureToAdd);
    // }

    // public void DeleteFigure(Figure figureToDelete)
    // {
    //     int position = 0;

    //     for (int i = 0; i < _figures.Length; i++)
    //     {
    //         if (_figures[i].ID == figureToDelete.ID)
    //         {
    //             position = i;
    //             break;
    //         }
    //     }

    //     for (int i = position; i < _figures.Length - 1; i++)
    //     {
    //         _figures[i] = _figures[i + 1];
    //     }

    //     Array.Resize(ref _figures, _figures.Length - 1);
    // }

    public void Move(int x, int y)
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i].Move(x, y);
        }
    }

    public void Resize(int index)
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i].Resize(index);
        }
    }


}
