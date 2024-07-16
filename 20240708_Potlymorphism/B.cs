namespace _20240708_Potlymorphism;

public class B : A
{
    // new - hide the parent method with the same name (just for compilator)
    public new void f1()
    {
        System.Console.WriteLine("B/f1()");
    }

    public override void f2()   //replacement of the virtual method behaviour
    {
        System.Console.WriteLine("B/f2()");
    }
}
