using System.Collections;

namespace _20240701_HW_Inheritence;

public class PictureComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        IGeometrical ig1 = x as IGeometrical;
        IGeometrical ig2 = y as IGeometrical;

        if (ig1 == null)
        {
            return -1;
        }

        if (ig2 == null)
        {
            return 1;
        }

        int diff = ig1.GetPerimeter() - ig2.GetPerimeter();

        if (diff > 0)
        {
            return 1;
        }

        if (diff < 0)
        {
            return -1;
        }

        return 0;
    }
}
