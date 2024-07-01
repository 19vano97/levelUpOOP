using System.Drawing;
using _20240618_Lesson25Class;

internal class Program
{
    private static void Main(string[] args)
    {
        TestClass t1 = new TestClass(); // контруктор по умолначнию создается сам по себе

        Point p0 = new Point(); //default ctor
        Point p1 = null; //null

        Show(p1);

        Point p2 = new Point(12, 4);    //memoyy is used

        Point p2Copy = p2; // copy of reference (bad idea)
    }

    public static void Show(Point p)
    {
        if (p == null)
        {
            return;
        }

        Console.SetCursorPosition(p.X, p.Y);
        //Console.Write($"({x}, {y})");
        Console.Write("*");
    }
}

    // клас - користувацбкий тип даних, який надаэ можливысть обэднати декылька типыв даних для отпису сутносты предметноъ галузы
    // структура - облехченный вариант организации классов
    // отличия: 
    // 1) класc - ref тип, используется в heap (куча) памяти 
    // 2) класc могу иметь конструктор по умолчанию (default constructor) 
    // 3) inheritance (наследование) / virtual methods

    // object или экземпляр класса - переменная, тип которого описывает (определяет) класс
    // когда нет конструктора по умолчанию для классов - /нет сам создает его