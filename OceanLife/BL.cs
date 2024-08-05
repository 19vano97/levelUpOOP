using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace OceanLife;

public class BL
{
    public static int GetRandomInt(int minValue = 0, int maxValue = int.MaxValue)
    {
        Random rnd = new Random();

        return rnd.Next(minValue, maxValue);
    }
}
