using System.Collections;
using _20240522_HW20;

namespace StudentStructHW20;

public class StudentComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        Student? s1 = x as Student;
        Student? s2 = y as Student;

        if (s2 == null)
        {
            return 1;
        }

        if (s1 == null)
        {
            return -1;
        }

        if (s1.StudentAvgMark > s2.StudentAvgMark)
        {
            return 1;
        }

        if (s1.StudentAvgMark < s2.StudentAvgMark)
        {
            return -1;
        }

        return 0;
    }
}
