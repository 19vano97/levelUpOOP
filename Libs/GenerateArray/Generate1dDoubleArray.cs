namespace GenerateArray;

public class Generate1dArray
{
    string _type;
    int _numberOfElements;
    double[]? _doubles;

    public Generate1dArray(string d, int numberOfElements)
    {
        _type = (string)d.Clone();
        _numberOfElements = numberOfElements;
    }

    public double[] Doubles
    {
        get => _doubles;
    }

    public void Generate()
    {
        if (_type == "double")
        {
            GenerateDoubleArray();
        }
    }

    public void GenerateDoubleArray()
    {
        _doubles = new double[_numberOfElements];

        for (int i = 0; i < _numberOfElements; i++)
        {
            _doubles[i] = GetRandomDouble();
        }
    }

    private double GetRandomDouble(int min = 0, int max = 100)
    {
        Random rnd = new Random();

        return rnd.Next(min, max);
    }
}
