namespace Galaga;

public class BL
{
    public static int GetRandomInt(int minValue = 0, int maxValue = int.MaxValue)
    {
        Random rnd = new Random();

        int value = rnd.Next(minValue, maxValue);

        return value;
    }
}
