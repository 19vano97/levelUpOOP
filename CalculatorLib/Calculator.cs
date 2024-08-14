using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class Calculator
    {
        public static int DevWithException(int first, int second)
        {
            int result = 0;

            try
            {
                result = first / second;
            }
            catch (DivideByZeroException ex)
            {
                throw new MyDivByZerroException(first, second, ex);
            }

            return result;
        }
    }
}
