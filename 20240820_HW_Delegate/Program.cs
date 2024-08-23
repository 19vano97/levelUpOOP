using GenerateArray;

internal class Program
{
    private static void Main(string[] args)
    {
        Generate1dArray dGen = new Generate1dArray("double", 6);

        double[] d1 = (double[])dGen.Doubles.Clone();

        for (int i = 0; i < d1.Length; i++)
        {
            System.Console.WriteLine(d1[i]);
        }
    }
}