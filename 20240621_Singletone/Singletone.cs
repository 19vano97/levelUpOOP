namespace _20240621_Singletone;

public class Singletone
{
    #region private variables
        //noway to send params to ctor
        private static Singletone _instance = new Singletone();
        private int _number;
        private Singletone()
        {}

        public static Singletone GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singletone();
            }

            return _instance;
        }

        private Singletone(int initValue)
        {
            
        }

    #endregion
}
