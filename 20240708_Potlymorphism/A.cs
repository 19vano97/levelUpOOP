namespace _20240708_Potlymorphism;

public class A
{
    public void f1()
    {
        System.Console.WriteLine("A/f1()");
    }

    public virtual void f2()    //new virual method or advertiment of the polymorph behaviour
    {
        System.Console.WriteLine("A/f2()");
    }

    
}
