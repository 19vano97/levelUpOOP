using System.Collections;
using _20240729_Lesson_Iterator;

internal class Program
{
    private static void Main(string[] args)
    {
         Container c1 = new Container(31, -21, 331, -98, 0 , 12);

            Console.WriteLine("c1 (iteration with while):");

            if (c1 is IEnumerable) 
            {
                IEnumerable i1c1 = (IEnumerable)c1;

                IEnumerator iter = i1c1.GetEnumerator();
                while (iter.MoveNext())
                {
                    Console.Write("{0} ", iter.Current);
                }
                Console.WriteLine();
            }

            Console.WriteLine("c1 (iteration with foreach):");
            foreach (int item in c1)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            //Test t1 = new Test();

            //foreach (var item in t1)
            //{

            //}

            int[] src = new int[] { 2, -2, 3, -54 };

            Console.WriteLine("src:");
            foreach (int item in src)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            for (int i = 0; i < src.Length; i++)
            {
                Console.Write("{0} ", src[i]);
            }
            Console.WriteLine();

            Console.ReadKey();
    }
}