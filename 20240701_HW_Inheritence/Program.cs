using _20240701_HW_Inheritence;

internal class Program
{
    private static void Main(string[] args)
    {
        #region main                 
            
            Picture pic1 = new Picture("pic1");

            Square sqr = new Square(50, 10, 4);
            Square sqr1 = new Square(52, 10, 4);

            pic1.Add(sqr);

            Circle c1 = new Circle(50,20,5);

            pic1.Add(c1);

            pic1.Add(new Rectangle(56, 15, 10, 5)); 

            UI.DrawPicture(pic1);
            Console.ReadKey(); 

            pic1.Resize(2);         

            UI.DrawPicture(pic1);
            Console.ReadKey();

            pic1.Move(3, -3);

            UI.DrawPicture(pic1);
            Console.ReadKey();

            UI.PrintIGeometrical(c1);
            UI.PrintIGeometrical(sqr);
            UI.PrintIGeometrical(sqr1);


            UI.PrintIGeometrical(pic1);

        #endregion
    }
}