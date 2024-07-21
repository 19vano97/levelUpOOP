namespace _20240719_Lesson_interface;

public struct Container2 : IConteiner
{
    private int[] _items;

    public Container2(params int[] items)
    {
        _items = (int[])items.Clone();
    }

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
