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

            #region Робота з ланцюжком викликів

            ArithmeticOperation op2 = null;

            if (op2 != null) 
            {
                double result10 = op2(agr1, arg2);
            }

            op2 = CalcSumma;

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            double result11 = op2(agr1, arg2);
            Console.WriteLine("result11: {0}", result11);

            // += - перевантажений оператор для додавання методу в лнцюжок викликів
            op2 += CalcMult;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            double result12 = op2(agr1, arg2);
            Console.WriteLine("result12: {0}", result12);

            op2 += CalcSumma;
            op2 += CalcSumma;
            op2 += CalcSumma;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            double result13 = op2(agr1, arg2);
            Console.WriteLine("result13: {0}", result13);

            // -= - перевантажений оператор для вилучення методу з лнцюжка викликів
            op2 -= CalcSumma;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            double result14 = op2(agr1, arg2);
            Console.WriteLine("result14: {0}", result14);

            op2 -= CalcMult;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            double result15 = op2(agr1, arg2);
            Console.WriteLine("result15: {0}", result15);

            #endregion


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
