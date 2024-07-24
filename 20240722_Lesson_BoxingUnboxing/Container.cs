using System.ComponentModel;

namespace _20240722_Lesson_BoxingUnboxing;

public class Container
{
    private object[] _items;

    public Container(params object[] items)
    {
        _items = (object[])items.Clone();
    }

    public void Add(object item)
    {
        Array.Resize(ref _items, _items.Length + 1);

        _items[_items.Length - 1] = item;
    }

    public int Size
    {
        get
        {
            return _items.Length;
        }
    }

    public object this[int index]
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
}
