using _20240628_HW26;

internal class Program
{
    private static void Main(string[] args)
    {

        #region Plus

            MathOperators arg1 = new MathOperators();
            MathOperators arg2 = new MathOperators();
    
            MathOperators plus = arg1 + arg2;
    
            System.Console.WriteLine("{0} = {1} + {2}", plus.ToString(), arg1.ToString(), arg2.ToString());
            
        #endregion
        
        #region Minus

            MathOperators arg3 = new MathOperators();
            MathOperators arg4 = new MathOperators();
    
            MathOperators minus = arg3 - arg4;
    
           System.Console.WriteLine("{0} = {1} - {2}", minus.ToString(), arg3.ToString(), arg4.ToString());

        #endregion
        
        #region Multiply

            MathOperators arg5 = new MathOperators();
            MathOperators arg6 = new MathOperators();
    
            MathOperators multiply = arg5 * arg6;
    
            System.Console.WriteLine("{0} = {1} * {2}", multiply.ToString(), arg5.ToString(), arg6.ToString());

        #endregion
        
        #region Divide

            MathOperators arg7 = new MathOperators();
            MathOperators arg8 = new MathOperators();
    
            MathOperators divide = arg1 / arg2;
    
            System.Console.WriteLine("{0} = {1} / {2}", divide.ToString(), arg7.ToString(), arg8.ToString());

        #endregion
        
        
        #region Fraction

            double fraction = 0.45;
            
            MathOperators fractionDiv = MathOperators.GetDefaultFrationBasedOnDouble(fraction);
    
            System.Console.WriteLine("{0}", fractionDiv.ToString());


        #endregion
    }
}