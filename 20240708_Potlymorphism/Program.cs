using _20240708_Potlymorphism;

internal class Program
{
    private static void Main(string[] args)
    {
        {A obj1 = new A();
        B obj2 = new B();
        C obj3 = new C();

        obj1.f1();
        obj2.f1();
        obj3.f1();

        //upcast
        DoF2AsRefA(obj1);
        DoF2AsRefA(obj2); // B -> A
        DoF2AsRefA(obj3); // C -> A

        // DoF1AsRefB(obj1);s
        DoF2AsRefB(obj2); // B -> B
        DoF2AsRefB(obj3); // C -> B

        // RTTI
        DoF2(obj1); 
        DoF2(obj2); // B -> A
        DoF2(obj3); // C -> A}

        }

        {
            A obj1 = new A();
            B obj2 = new B();
            C obj3 = new C();

            obj1.f2();
            obj2.f2();
            obj3.f2();

            //upcast
            DoF1AsRefA(obj1);
            DoF1AsRefA(obj2); // B -> A
            DoF1AsRefA(obj3); // C -> A

            // DoF1AsRefB(obj1);s
            DoF1AsRefB(obj2); // B -> B
            DoF1AsRefB(obj3); // C -> B

            // RTTI
            DoF1(obj1); 
            DoF1(obj2); // B -> A
            DoF1(obj3); // C -> A
        }

        {
            Container c1 = new Container(
                new B(),
                new C(),
                new A(),
                new D()
            );

            c1.DoF2();
        }

    }

    public static void DoF1AsRefA(A obj)
    {
        obj.f1();
    }

    public static void DoF1AsRefB(B obj)
    {
        obj.f1();
    }

    public static void DoF2AsRefA(A obj)
    {
        obj.f2();
    }

    public static void DoF2AsRefB(B obj)
    {
        obj.f2();
    }

    //RTTI
    // is
    // public static void DoF1(A obj)
    // {
    //     if (obj is B)
    //     {
    //         ((B)obj).f1();
    //     }
    //     else
    //     {
    //         obj.f1();
    //     }
    // }

    //as
    public static void DoF1(A obj)
    {
        C objc = obj as C; //downcast
        
        if (objc != null)
        {
            objc.f1();
        }
        else
        {
            B objB = obj as B; //downcast

            if (objB != null)
            {
                objB.f1();
            }
            else
            {
                obj.f1();
            }
        }

        //bad apporach    
        // if (obj is C)
        // {
        //     (obj as C).f1();    //downcast RTTI
        // }
        // else
        // {

        //     if (obj is B)
        //     {
        //         (obj as B).f1();    //downcast RTTI
        //     }
        //     else
        //     {
        //         obj.f1();
        //     }
        // }
    }
    
    public static void DoF2(A obj)
    {
        obj.f2();
    }
}

// polymophism - one interface - multiple realization

// static
//      function overloading
//      operation overloading
//      params
//      Markers: address of a calling method defines on the compilation step

//  dynamic
//      Markers: address of a calling method defines on the runtime step

// polymorphisn in classes
//      - inheritance
//      - upcast - reference to the parent class can store an address of the derived clasee
//      - virtual methods

// callback functions (delegates)

//  reflaction 

// RTTI operations
//      run time type information
//      1) is - check the reference that it contains example of data type
//          <reference> is <data type>
//          returns: true or false
//      2) as - cast reference to another refrerence of any data type
//          <reference> as <data type>
//          returns: 
//            -  1) reference to adressed data type
//              2) null - reference doesnt containe an object of addressed type


// virtual methods
//      virtual - is a virtual method in the parent class 
//      override - override of the virtual method in the derive class
//      sealed - restricts override of the virtual method in the dervied classes

//table of virtual methods
//    class   |    Method name  |   Method address
//------------|-----------------|---------------------
//      A     |     F2          |       addr1
//      B     |     F2          |       addr2
//      C     |     F2          |       addr3

// for virtual methids there is a check of exampliar of the calss was created  whcih has a reference (to the parent class) and there is a call from the class
