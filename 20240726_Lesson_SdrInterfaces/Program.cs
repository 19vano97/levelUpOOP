using _20240726_Lesson_SdrInterfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person()
        {
            INN = 1,
            FirstName = "hey",
            LastName = "world"
        };

        Person p2 = new Person()
        {
            INN = 2,
            FirstName = "hey",
            LastName = "anno"
        };

        Person p3 = new Person()
        {
            INN = 3,
            FirstName = "hey",
            LastName = "mundi"
        };

        Person[] people = new Person[] {p1, p2, p3};

        for (int i = 0; i < people.Length; i++)
        {
            System.Console.WriteLine("p{0}: {1}", i, people[i]);
        }

        Array.Sort(people);
    }

    public static void TestCopy(object source)
    {
        if (source != null && source is ICloneable)
        {
            Person pCopy = (Person)((ICloneable)source).Clone();

            pCopy.LastName = "heaven";

            System.Console.WriteLine("Source: {0}", source);
            System.Console.WriteLine("copy: {0}", pCopy);
        }
    }
}