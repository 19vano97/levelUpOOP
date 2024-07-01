using _20240628_HW26;

internal class Program
{
    private static void Main(string[] args)
    {

        #region Plus

            MathOperators arg1 = new MathOperators();
            MathOperators arg2 = new MathOperators();
    
            MathOperators plus = arg1 + arg2;
    
            System.Console.WriteLine("1. {0} = {1} + {2}", plus.GetNumber1, arg1.GetNumber1, arg2.GetNumber1);
            System.Console.WriteLine("2. {0} = {1} + {2}", plus.GetNumber2, arg1.GetNumber2, arg2.GetNumber2);
            
        #endregion
        
        #region Minus

            MathOperators arg3 = new MathOperators();
            MathOperators arg4 = new MathOperators();
    
            MathOperators minus = arg1 - arg2;
    
            System.Console.WriteLine("1. {0} = {1} - {2}", minus.GetNumber1, arg3.GetNumber1, arg4.GetNumber1);
            System.Console.WriteLine("2. {0} = {1} - {2}", minus.GetNumber2, arg3.GetNumber2, arg4.GetNumber2);

        #endregion
        
        #region Multiply

            MathOperators arg5 = new MathOperators();
            MathOperators arg6 = new MathOperators();
    
            MathOperators multiply = arg1 * arg2;
    
            System.Console.WriteLine("1. {0} = {1} * {2}", multiply.GetNumber1, arg5.GetNumber1, arg6.GetNumber1);
            System.Console.WriteLine("2. {0} = {1} * {2}", multiply.GetNumber2, arg5.GetNumber2, arg6.GetNumber2);

        #endregion
        
        #region Divide

            MathOperators arg7 = new MathOperators();
            MathOperators arg8 = new MathOperators();
    
            double[] divide = arg1 / arg2;
    
            System.Console.WriteLine("1. {0} = {1} / {2}", divide[0], arg7.GetNumber1, arg8.GetNumber1);
            System.Console.WriteLine("2. {0} = {1} / {2}", divide[1], arg7.GetNumber2, arg8.GetNumber2);

        #endregion
        
        
        #region Fraction

            double fraction = 0.45;
            
            MathOperators fractionDiv = MathOperators.GetDefaultFrationBasedOnDouble(fraction);
    
            System.Console.WriteLine("Numerable: {0}", fractionDiv.GetNumber1);
            System.Console.WriteLine("Denumerable: {0}", fractionDiv.GetNumber2);
    
            double test = (double)fractionDiv.GetNumber1 / (double)fractionDiv.GetNumber2;
    
            System.Console.WriteLine("Original: {0}, Check: {1}", fraction, test);

        #endregion
    }
}