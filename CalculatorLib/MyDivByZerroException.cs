using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class MyDivByZerroException: Exception
    {
        public int FirstArgument { get; private set; } 

        public int SecondArgument { get; private set; }

        public MyDivByZerroException(int first, int second, Exception innerException = null)
            : base("Wrong! Divide by zerro!", innerException)
        {
            FirstArgument = first; 
            SecondArgument = second;
        }

        public MyDivByZerroException()
        {
                
        }

        public MyDivByZerroException(string message)
            : base(message) 
        {
                
        }

        public MyDivByZerroException(string message, Exception innerException)
            : base(message, innerException) 
        {
            
        }


    }
}
