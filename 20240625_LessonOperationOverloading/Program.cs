using _20240625_LessonOperationOverloading;

internal class Program
{
    private static void Main(string[] args)
    {
        MyInt a = new MyInt(10);
        System.Console.WriteLine("a = {0}", a.Number);
        
        MyInt b = new MyInt(15);
        System.Console.WriteLine("b = {0}", b.Number);

        MyInt c1 = MyInt.Add(a,  b);

        MyInt c2 = a.Add(b).Add(b);

        MyInt c3 = a + b; //25
    }
}