
namespace _20240701_HW_Inheritence;

public class Figure
{
    #region variables

        protected Guid _id = Guid.NewGuid();
        protected Square _square;
        protected Rectangle _rectangle;
        protected Circle _circle;
        protected FigureList _figureList;
        
    #endregion

    #region default ctors

        public Figure(Square squareToAdd)
        {
            _square = squareToAdd;
            _figureList = FigureList.Square;
        }
    
        public Figure(Rectangle rectangleToAdd)
        {
            _rectangle = rectangleToAdd;
            _figureList = FigureList.Rectangle;
        }
    
        public Figure(Circle circleToAdd)
        {
            _circle = circleToAdd;
            _figureList = FigureList.Circle;
        }

    #endregion

    // public void Move(int x, int y)
    // {
    //     if (_figureList.HasFlag(FigureList.Square))
    //     {
    //         _square.Move(x, y);
    //     }

    //     if (_figureList.HasFlag(FigureList.Rectangle))
    //     {
    //         _rectangle.Move(x, y);
    //     }

    //     if (_figureList.HasFlag(FigureList.Circle))
    //     {
    //         _circle.Move(x, y);
    //     }
    // }

    // public async Task MoveAsync(int x, int y)
    // {
    //     string figureVar = _figureList.ToString().ToLower();

    //     string code = $"_{figureVar}.Move(x, y);";

    //     System.Console.WriteLine(code);

    //     await CSharpScript.RunAsync(code, ScriptOptions.Default.WithReferences(AppDomain.CurrentDomain.GetAssemblies()).WithImports("System"));


    // }

    public void Resize(int index)
    {
        if (_figureList.HasFlag(FigureList.Square))
        {
            _square.Resize(_square.Points, index);
        }

        if (_figureList.HasFlag(FigureList.Rectangle))
        {
            _rectangle.Resize(_rectangle.Points, index);
        }

        if (_figureList.HasFlag(FigureList.Circle))
        {
            _circle.Resize(index);
        }
    }

    public FigureList FigureName
    {
        get
        {
            return _figureList;
        }
    }

    public Guid ID
    {
        get
        {
            return _id;
        }
    }
}
