using System.Runtime.InteropServices;

namespace _20240807_HW_Exceptions;

public class Equation
{
    #region variables

        private double[] _x;
        private int _a;
        private int _b;
        private int _c;
        private int _d;

    #endregion

    #region default ctor

        public Equation(int a, int b, int c)
        {
            _a = CheckTheFirstArg(a);
            _b = b;
            _c = c;
        }

        public Equation()
        {}

    #endregion

    #region props

        public int A
        {
            get => _a;
            set
            {
                if (value == 0)
                {
                    throw new EquationInvalidDataException(_a);
                }

                _a = value;
            }
        }

        public int B
        {
            get => _b;
            set => _b = value;
        }

        public int C
        {
            get => _c;
            set => _c = value;
        }

        public int D
        {
            get => _d;
        }

        public double[] X
        {
            get
            {
                if (_x == null)
                {
                    throw new EquationInvalidDataException(_x, "There is no result yet.");
                }

                return _x;
            }
        }

        public double this[int index]
        {
            get 
            {
                //No sence: System.IndexOutOfRangeException: Index was outside the bounds of the array.

                try
                {
                    return _x[index];
                }
                catch (System.IndexOutOfRangeException)
                {
                    throw new EquationInvalidDataException(_x[index], "There is no any result");
                }
            }
            set 
            {
                //No sence: System.IndexOutOfRangeException: Index was outside the bounds of the array.
                
                try
                {
                    _x[index] = value;
                }
                catch (System.IndexOutOfRangeException)
                {
                    throw new EquationInvalidDataException(_x[index], "There is no any result");
                }
            }
        }
        
    #endregion

    private int CheckTheFirstArg(int a)
    {
        if (a == 0)
        {
            throw new EquationInvalidDataException(a);
        }

        return a;
    }

    public void CalculateEquation()
    {
        _d = (int)(Math.Pow(_b, 2) - 4 * _a * _c);

        if (_d == 0)
        {
            _x = new double[1];

            try
            {
                _x[0] = (-_b) / (2 * _a);
            }
            catch (System.DivideByZeroException)
            {
                throw new EquationInvalidDataException(X[0]);
            }
        }
        else
        {
            _x = new double[2];

            double x1Num = -_b + Math.Sqrt(_d);
            double x2Num = -_b - Math.Sqrt(_d);

            try
            {
                _x[0] = x1Num / (2 * _a);
                _x[1] = x2Num / (2 * _a);
            }
            catch (System.DivideByZeroException)
            {
                throw new EquationInvalidDataException(X[0], X[1]);
            }
        }
    }

    public override string ToString()
    {
        if (_x == null)
        {
            return string.Format("{0}x^2 + {1}x + {2} = 0", _a, _b, _c);
        }
        else
        {
            if (_x.Length == 1)
            {
                return string.Format("{0}x^2 + {1}x + {2} = 0 \nx={3}", _a, _b, _c, _x[0]);
            }
            else
            {
                return string.Format("{0}x^2 + {1}x + {2} = 0 \nx1 = {3} \nx2 = {4}", _a, _b, _c, _x[0], _x[1]);
            }
        }
    }



}
