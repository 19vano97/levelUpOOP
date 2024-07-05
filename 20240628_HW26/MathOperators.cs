namespace _20240628_HW26;

public class MathOperators
{
    #region data
        
        private int _numerator;
        private int _denumerator;
        private const int MAX_RANDOM = 100;

    #endregion

    public MathOperators(int param1, int param2)
    {
        _numerator = param1;

        if (param2 == 0)
        {
            return;
        }
        
        _denumerator = param2;
    }

    public MathOperators() : this (GetRandomInt(), GetRandomInt())
    {
        _numerator = GetRandomInt();
        _denumerator = GetRandomInt();
    }

    public int GetNumber1 { get {return _numerator;} }
    public int GetNumber2 { get {return _denumerator;} }

    public static MathOperators operator +(MathOperators firstArg, MathOperators secondArg)
    {
        int numeratorN = firstArg._numerator * secondArg._denumerator + secondArg._numerator * firstArg._denumerator;
        int denumeratorN = firstArg._denumerator * secondArg._denumerator;

        int[] nomalizedFraction = MinimizeFraction(numeratorN, denumeratorN);

        return new MathOperators(nomalizedFraction[0], nomalizedFraction[1]);
    }

    public static MathOperators operator -(MathOperators firstArg, MathOperators secondArg)
    {
        int numeratorN = firstArg._numerator * secondArg._denumerator - secondArg._numerator * firstArg._denumerator;
        int denumeratorN = firstArg._denumerator * secondArg._denumerator;

        int[] nomalizedFraction = MinimizeFraction(numeratorN, denumeratorN);

        return new MathOperators(nomalizedFraction[0], nomalizedFraction[1]);
    }

    public static MathOperators operator *(MathOperators firstArg, MathOperators secondArg)
    {
        int numeratorN = firstArg._numerator *  secondArg._numerator;
        int denumeratorN = firstArg._denumerator * secondArg._denumerator;

        int[] nomalizedFraction = MinimizeFraction(numeratorN, denumeratorN);

        return new MathOperators(nomalizedFraction[0], nomalizedFraction[1]);
    }

    public static MathOperators operator /(MathOperators firstArg, MathOperators secondArg)
    {
        int numeratorN = firstArg._numerator *  secondArg._denumerator;
        int denumeratorN = firstArg._denumerator * secondArg._numerator;

        int[] nomalizedFraction = MinimizeFraction(numeratorN, denumeratorN);

        return new MathOperators(nomalizedFraction[0], nomalizedFraction[1]);
    }

    public static bool operator >(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._numerator > secondArg._numerator + 2 && firstArg._denumerator > secondArg._denumerator + 2;
    }

    public static bool operator <(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._numerator < secondArg._numerator + 2 && firstArg._denumerator < secondArg._denumerator + 2;
    }

    public static int operator %(MathOperators firstArg, MathOperators secondArg)
    {
        return firstArg._numerator % secondArg._numerator;
    }

    public static implicit operator int(MathOperators value)
    {
        return value._numerator + 2;
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

        return rnd.Next(1, MAX_RANDOM);
    }

    public override string ToString()
    {
        return string.Format("{0} / {1}", _numerator, _denumerator);
    }
}
