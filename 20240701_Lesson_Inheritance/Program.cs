namespace _20240701_Lesson_Inheritance;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person(123, "nann");
        Person p2 = new Person(123, "nann");
        Person p3 = new Person(124, "hero");
        Person p4 = new Person(125, "huc3");
        // p1.Equals 

        if (!p2.Equals(p1))
        {
            System.Console.WriteLine(":(");
        }
        else
        {
            System.Console.WriteLine(":)");
        }

        Person[] people = [p1, p2, p3, p4];

        if (people.Contains(new Person(1221, "hi")))
        {
            System.Console.WriteLine("Existed");
        }

        for (int i = 0; i < people.Length; i++)
        {
            System.Console.WriteLine(people[i]);
        }

    }
}