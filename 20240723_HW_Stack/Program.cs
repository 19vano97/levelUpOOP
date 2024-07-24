using System.ComponentModel;

namespace _20240723_HW_Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        Stack s1 = new Stack(1, 32, -5, -654.566, "hello world");

        System.Console.WriteLine("IsFull: {0}", s1.IsFull());
        System.Console.WriteLine("IsEmpty: {0}", s1.IsEmpty());

        for (int i = 0; i < s1.Size; i++)
        {
            s1.Pop();
        }

        System.Console.WriteLine("IsFull after Pop: {0}", s1.IsFull());
        System.Console.WriteLine("IsEmpty after Pop: {0}", s1.IsEmpty());

        s1.Push(5);

        for (int i = 0; i < s1.Size; i++)
        {
            System.Console.WriteLine(s1[i]);
        }
        System.Console.WriteLine(s1.Peek());

        
    }
}