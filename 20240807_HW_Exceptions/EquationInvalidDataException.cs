using System;

namespace _20240807_HW_Exceptions;

public class EquationInvalidDataException : Exception
{
    public int firstArg {get; private set;}
    public int secondArg {get; private set;}
    public int thirdArg {get; private set;}
    public double X1 {get; private set;} 
    public double X2 {get; private set;} 

    public EquationInvalidDataException(int a, System.Exception inner = null)
        : base("The fist argument cannot be 0", inner)
    {
        firstArg = a;
    }

    public EquationInvalidDataException(double x1, double x2 = 0d, System.Exception inner = null)
        : base("Infinite response. Try to use other arguments", inner)
    {
        X1 = x1;
        X2 = x2;
    }

    public EquationInvalidDataException(double[] x, string message, Exception inner = null)
        : base(message, inner)
    {}

    public EquationInvalidDataException(double x, string message, Exception inner = null)
        : base(message, inner)
    {
        X1 = x;
    }

    public EquationInvalidDataException() { }
    public EquationInvalidDataException(string message) : base(message) { }
    public EquationInvalidDataException(string message, System.Exception inner) : base(message, inner) { }
    protected EquationInvalidDataException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
