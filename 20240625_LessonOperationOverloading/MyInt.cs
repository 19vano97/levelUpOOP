namespace _20240625_LessonOperationOverloading;

public class MyInt
{
    #region Data

        private int _number;
        
    #endregion

    public MyInt(int number)
    {
        _number = number;
    }

    public int Number 
    { 
        get
        {
            return _number;
        }
    }

    public static MyInt Add(MyInt firstArg, MyInt secondArg)
    {
        int result = firstArg._number + secondArg._number;

        return new MyInt(result);
    }

    public MyInt Add(MyInt other)
    {
        _number += other._number;

        return this;
    }

    #region arithmetic operation
        
    public static MyInt operator+(MyInt firstArg, MyInt secondArg)
    {
        int result = firstArg._number + secondArg._number;

        return new MyInt(result);
    }

    #endregion
}
