using System.ComponentModel;

namespace _20240722_Lesson_BoxingUnboxing;

internal class Program
{
    private static void Main(string[] args)
    {
        #region demo

            int k = 23;
    
            object m = k;   //boxing
    
            int kCopy = (int)m; //unboxing

        #endregion

        Container c1 = new Container(12, -5, 27, -28, 0, 21);

        for (int i = 0; i < c1.Size; i++)
        {
            System.Console.WriteLine("{0}", c1[i]);
        }

        Container c2 = new Container(1.2, -5.4, 27.77, -28.23, 0.32423, 21);

        for (int i = 0; i < c2.Size; i++)
        {
            System.Console.WriteLine("{0}", c2[i]);
        }
    }
}

// boxing/unboxing

// boxing - a way to store a reference to the object value for VALUE TYPES

//  disadv - to boxing it takes some time; there is no control of types during boxing and unboxing