namespace _20240807_HW_Exceptions;

public class Equation
{
    #region variables

        private double[] _x;
        private int _a;
        private int _b;
        private int _c;

    #endregion

    #region default ctor

        public Equation(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;

            CalculateEquation();

            System.Console.WriteLine("x1 = {0}, x2 = {1}", _x[0], _x[1]);
        }

    #endregion

    #region props

        public double[] X
        {
            get => _x;
            set => _x = value;
        }

        public int A
        {
            get => _a;
            set => _a = value;
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
        
    #endregion

    private void CalculateEquation()
    {
        int d = (int)(Math.Pow(_b, 2) - 4 * _a * _c);

        if (d == 0)
        {
            _x = new double[1];

            _x[0] = (-_b) / 2 * _a;
        }
        else
        {
            _x = new double[2];

            double x1Num = -_b + Math.Sqrt(d);
            double x2Num = -_b - Math.Sqrt(d);

            _x[0] = x1Num / (2 * _a);
            _x[1] = x2Num / (2 * _a);

            if (double.IsNaN(_x[0]) || double.IsNaN(_x[1]))
            {
                throw new ArithmeticException("x - param equals infinite");
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
