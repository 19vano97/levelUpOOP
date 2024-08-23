using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240816_DelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double agr1 = 10.3;
            double arg2 = -3.5;

            double result1 = CalcSumma(agr1, arg2);

            Console.WriteLine("result1: {0}", result1);

            ArithmeticOperation op1 = CalcSumma;    // присвоєння адреси методу в змінну типу делегат

            Console.ForegroundColor = ConsoleColor.Green;

            double result2 = op1(agr1, arg2);

            Console.WriteLine("result2: {0}", result2);

            //op1 = CalcMult;    // присвоєння адреси методу в змінну типу делегат

            Console.ForegroundColor = ConsoleColor.Red;

            //double result3 = op1(agr1, arg2);

            //Console.WriteLine("result3: {0}", result3);

            DoCalculate(agr1, arg2, CalcMult);

            #region Standart delegates

            int[] source = new int[] { -12, -4, 23, -100 };

            bool existedItemMoreThanZerro = Array.Exists(source, IsMoreThanZerro);

            #endregion

            Console.ReadKey();
        }

        public static bool IsMoreThanZerro(int number)
        {
            return number > 0;
        }

        public static double CalcSumma(double first, double second)
        {
            Console.WriteLine("CalcSumma({0}, {1})", first, second);

            return first + second;
        }

        public static double CalcMult(double first, double second)
        {
            Console.WriteLine("CalcMult({0}, {1})", first, second);

            return first * second;
        }

        public static void DoCalculate(double first, double second, ArithmeticOperation op)
        {
            double result = op(first, second);

            Console.WriteLine("result: {0}", result);
        }
    }
}
