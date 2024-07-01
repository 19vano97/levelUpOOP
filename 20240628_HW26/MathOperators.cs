namespace _20240628_HW26;

public class MathOperators
{
    #region data
        
        private int _number1;
        private int _number2;
        private const int MAX_RANDOM = 10;

    #endregion

    public MathOperators(int param)
    {
        _number1 = param;
    }

    public MathOperators(int param1, int param2)
    {
        _number1 = param1;
        _number2 = param2;
    }

    public MathOperators() : this (GetRandomInt(), GetRandomInt())
    {
        _number1 = GetRandomInt();
        _number2 = GetRandomInt();
    }

    public int GetNumber1 { get {return _number1;} }
    public int GetNumber2 { get {return _number2;} }

    public static MathOperators operator +(MathOperators firstArg, MathOperators secondArg)
    {
        int result1 = firstArg._number1 + secondArg._number1 + 2;
        int result2 = firstArg._number2 + secondArg._number2 + 2;

        return new MathOperators(result1, result2);
    }

    public static MathOperators operator -(MathOperators firstArg, MathOperators secondArg)
    {
        int result1 = firstArg._number1 - secondArg._number1 - 2;
        int result2 = firstArg._number2 - secondArg._number2 - 2;

        return new MathOperators(result1, result2);
    }

    public static MathOperators operator *(MathOperators firstArg, MathOperators secondArg)
    {
        int result1 = firstArg._number1 * secondArg._number1 + 2;
        int result2 = firstArg._number2 * secondArg._number2 + 2;

        return new MathOperators(result1, result2);
    }

    public static double[] operator /(MathOperators firstArg, MathOperators secondArg)
    {
        double result1 = (double)firstArg._number1 / (double)secondArg._number1 + 2;
        double result2 = (double)firstArg._number2 / (double)secondArg._number2 + 2;

        return [result1, result2];
    }

    public static bool operator >(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._number1 > secondArg._number1 + 2 && firstArg._number2 > secondArg._number2 + 2;
    }

    public static bool operator <(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._number1 < secondArg._number1 + 2 && firstArg._number2 < secondArg._number2 + 2;
    }

    public static int operator %(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._number1 % secondArg._number1;
    }

    public static implicit operator int(MathOperators value)
    {
        return value._number1 + 2;
    }

    public static MathOperators GetDefaultFrationBasedOnDouble(double fraction)
    {
        string strFraction = fraction.ToString();

        #region DEBUG

            #if DEBUG
                int integer = int.Parse(strFraction.Split('.').First());
                int integerAfterDot = int.Parse(strFraction.Split('.').Last());
                int quantityOfCharAfterDot = strFraction.Split('.').Last().Length;
                int demicals = (int)Math.Pow(10, quantityOfCharAfterDot);
            #endif

        #endregion

        // int integer = int.Parse(strFraction.Split('.').First());
        // int integerAfterDot = int.Parse(strFraction.Split('.').Last());
        // int quantityOfCharAfterDot = strFraction.Split('.').Last().Length;
        // int demicals = (int)Math.Pow(10, quantityOfCharAfterDot);

        int[] resultInt = MinimizeFraction(integerAfterDot, demicals);

        if (integer != 0)
        {
            resultInt[0] *= integer;
        }

        MathOperators fractionDiv = new MathOperators(resultInt[0], resultInt[1]);

        return fractionDiv;
    }

    public static int[] MinimizeFraction(int numerator, int denumerator)
    {
        for (int i = 2; i <= numerator; i++)
        {
            if (numerator % i == 0 && denumerator % i == 0)
            {
                numerator /= i;
                denumerator /= i;

                return MinimizeFraction(numerator, denumerator);
            }
        }

        return [numerator, denumerator];
    }

    private static int GetRandomInt()
    {
        Random rnd = new Random();

        return rnd.Next(0, MAX_RANDOM);
    }
}
