using _20240701_HW_Inheritence;

internal class Program
{
    private static void Main(string[] args)
    {
        #if DEBUG

            Picture pic1 = new Picture("pic1");

            Quadrilateral newQuadrilateral = new Quadrilateral(12, 2, 4, pic1);
    
            Square newSquare = new Square(newQuadrilateral);
    
            Rectangle newRectangle = new Rectangle(newQuadrilateral, 3);
    
            newSquare.Rotate45(newSquare.Points);
    
            newRectangle.Resize(newRectangle.Points, 2);
    
            newRectangle.Rotate45(newRectangle.Points);


            Circle newCircle = new Circle(10, 10, 3, pic1);
            Circle circle = new Circle(20, 10, 5, pic1);

            
            circle.Resize(2);

            CircleInSquare circleInSquareToDraw = new CircleInSquare(20, 5, 10, pic1);
            circleInSquareToDraw.Resize(circleInSquareToDraw.Points, 2);


            Square squareForFigure = new Square(10, 10, 5, pic1);

            pic1.Move(2, 2);

            pic1.Add(newRectangle);
            pic1.Add(newSquare);
            pic1.Add(newCircle);

            pic1.Move(4, 2);
            
        #endif


        #region main

            // Picture pic1 = new Picture("pic1");

            // Quadrilateral newQuadrilateral = new Quadrilateral(12, 2, 4, pic1);
    
            // Square newSquare = new Square(newQuadrilateral);
    
            // UI.DrawQuadrilateral(newSquare.Points);
            // Console.ReadKey();
    
            // Rectangle newRectangle = new Rectangle(newQuadrilateral, 3);
            // UI.DrawQuadrilateral(newRectangle.Points);
    
            // Console.ReadKey();
    
            // newSquare.Rotate45(newSquare.Points);
            // UI.DrawQuadrilateral(newSquare.Points);
            // Console.ReadKey();
    
            // newRectangle.Resize(newRectangle.Points, 2);
            // UI.DrawQuadrilateral(newRectangle.Points);
            // Console.ReadKey();
    
            // newRectangle.Rotate45(newRectangle.Points);
            // UI.DrawQuadrilateral(newRectangle.Points);
            // Console.ReadKey();

            // Circle newCircle = new Circle(10, 10, 3, pic1);
            // UI.DrawCircle(newCircle);
            // Console.ReadKey();

            // Circle circle = new Circle(20, 10, 5, pic1);
            // UI.DrawCircle(circle);
            // Console.ReadKey();
            
            // circle.Resize(2);

            // UI.DrawCircle(circle);
            // Console.ReadKey();

            // CircleInSquare circleInSquareToDraw = new CircleInSquare(20, 5, 10, pic1);
            // // UI.DrawCircleInSquare(circleInSquareToDraw);
            // // Console.ReadKey();

            // circleInSquareToDraw.Resize(circleInSquareToDraw.Points, 2);
            // UI.DrawCircleInSquare(circleInSquareToDraw);
            // Console.ReadKey();

            // Square squareForFigure = new Square(10, 10, 5, pic1);
            // // UI.DrawSquare(squareForFigure);
            // Figure figure1 = new Figure(squareForFigure);
            // pic1.AddFigure(figure1);

            // pic1.Move(2, 2);

            // pic1.AddFigure(newRectangle);
            // pic1.AddFigure(newSquare);
                       
            

        #endregion
    }
}