using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CalculatorLib;

namespace _20240812_ExceptionDemoPartII
{
    internal class Program
    {
        const int ITERATIONS_COUNT = 1;

        static void Main(string[] args)
        {
            int a = 10;
            int b = 0;

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < ITERATIONS_COUNT; i++)
            {
                try
                {
                    int c = Calculator.DevWithException(a, b);
                    //Console.WriteLine("{0} / {1} = {2}", a, b, c);
                }
                catch (DivideByZeroException)
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Wrong operation!!!");
                }
                catch (MyDivByZerroException ex)
                {
                    Console.WriteLine("Exception:");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(ex);
                    Console.WriteLine("InnerException:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.InnerException);
                }
            }
            sw1.Stop();
            Console.WriteLine("   Time of DevWithException(): {0,7}msec, {1,8}ticks", sw1.ElapsedMilliseconds, sw1.ElapsedTicks);


            //Console.WriteLine();
            //Console.WriteLine();

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < ITERATIONS_COUNT; i++)
            {
                ErrorStatus err = DevWithoutException(a, b, out int c);

                switch (err)
                {
                    case ErrorStatus.Ok:
                        //Console.WriteLine("{0} / {1} = {2}", a, b, c);
                        break;
                    case ErrorStatus.DivByZerro:
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("Wrong operation!!!");
                        break;
                    default:
                        break;
                }

            }
            sw2.Stop();
            Console.WriteLine("Time of DevWithoutException(): {0,7}msec, {1,8}ticks", sw2.ElapsedMilliseconds, sw2.ElapsedTicks);

            Console.ReadKey();
        }


        // Exceptions:
        //     DivideByZeroException
        //public static int DevWithException(int first, int second)
        //{
        //    int result = 0;

        //    try
        //    {
        //        result = first / second;
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw new MyDivByZerroException(first, second, ex);
        //    }

        //    return result;
        //}

        public static ErrorStatus DevWithoutException(int first, int second, out int result)
        {
            ErrorStatus errorStatus = ErrorStatus.Ok;
            result = 0;

            if (second == 0)
            {
                errorStatus = ErrorStatus.DivByZerro;
            }
            else
            {
                result = first / second;
            }

            return errorStatus;
        }
    }
}
