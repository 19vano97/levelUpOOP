namespace _20240726_Lesson_SdrInterfaces;

public class Person : ICloneable, IComparable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int INN { get; set; }

    #region standard interfaces

        //clone
        public object Clone()
        {
            // return new Person(){INN = this.INN, FirstName = this.FirstName, LastName = this.LastName};
            return MemberwiseClone();
        }

        //compare
        public int CompareTo(object? obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return 1;
            }

            int result = 0;

            if (other.INN > INN)
            {
                result = 1;
            }
            else
            {
                if (other.INN < INN)
                {
                    result = -1;
                }
            }

            return result;
        }

    #endregion

    public override string ToString()
    {
        return string.Format("{0} - {1} {2}", INN, LastName, FirstName);
    }
}
