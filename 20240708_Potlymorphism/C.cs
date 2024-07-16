namespace _20240708_Potlymorphism;

public class C : B
{
    public new void f1()
    {
        System.Console.WriteLine("C/f1()");
    }

    public sealed override void f2()   //replacement of the virtual method behaviour
    {
        System.Console.WriteLine("B/f2()");
    }
}
