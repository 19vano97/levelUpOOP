namespace SortDoubleArray;

public abstract class SortDoubleArray
{
    private double _doubleArray;

    public SortDoubleArray(double[] doubleArray)
    {
        _doubleArray = (double)doubleArray.Clone();
    }

    public abstract double[] Sort();
}
