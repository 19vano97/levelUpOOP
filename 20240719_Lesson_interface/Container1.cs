namespace _20240719_Lesson_interface;

public class Container1 : IConteiner
{
    private int[] _items = new int[] {1, 2, 3};

    public int this[int index]
    {
        get
        {
            return _items[index];
        }
        set
        {
            _items[index] = value;
        }
    }
    public int size
    {
        get
        {
            return _items.Length;
        }
    }
}
