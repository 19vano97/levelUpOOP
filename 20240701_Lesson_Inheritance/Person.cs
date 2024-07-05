namespace _20240701_Lesson_Inheritance;

public class Person
{
    public long IPN { get; set; }
    public string Name { get; set; }
    
    public Person(long IPNN, string name)
    {
        IPN = IPNN;
        Name = name;
    }

    #region own apprach of equaling
    
        public override bool Equals(object? obj)
        {
            bool result = false;

            Person other= (Person)obj;

            if (IPN == other.IPN && Name == other.Name)
            {
                result = true;
            }

            return result;
        }

    public override string ToString()
    {
        //string result = base.ToString(); // provides info about class in string

        string result = string.Format("{0} - {1}", IPN, Name);

        return result;
    }


    public Person GetCopy()
    {
        Person copy = (Person)MemberwiseClone(); // creates copy of value types (as struct)

        copy._items = (int[])_items.Clone();
        
        return copy; 
    }

    #endregion
}
