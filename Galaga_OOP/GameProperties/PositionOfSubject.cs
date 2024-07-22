using System.Security.Cryptography.X509Certificates;

namespace Galaga_OOP;

public class PositionOfSubject
{
    #region variables

        private int _x;
        private int _y;

    #endregion

    #region default ctors

        public PositionOfSubject(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public PositionOfSubject() : this (0, 0)
        {}
        
    #endregion

    #region properties

        public int X
        {
            get
            {
                if (_x < 0)
                {
                    return 0;
                }

                return _x;
            }
            set
            {
                if (_x < 0)
                {
                    return;
                }

                _x = value;
            }
        }

        public int Y
        {
            get
            {
                if (_y < 0)
                {
                    return 0;
                }

                return _x;
            }
            set
            {
                if (_y < 0)
                {
                    return;
                }

                _y = value;
            }
        }

    #endregion


}
