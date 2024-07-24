namespace _20240723_HW_Stack;

public class Stack
{
    private object[] _items;


    public Stack(params object[] items)
    {
        _items = (object[])items.Clone();
    }

    public object[] Items
    {
        get
        {
            return _items;
        }
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

    private int GetLastIndex()
    {
        int index = 0;

        for (int i = _items.Length - 1; i >= 0; i--)
        {
            if (_items[i] != null)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public void Push(object item)
    {
        if (IsFull())
        {
            return;
        }

        if (GetLastIndex() > 0)
        {
            _items[GetLastIndex() + 1] = item;
            return;
        }

        _items[0] = item;
    }

    public object Peek()
    {     
        return _items[GetLastIndex()];
    }

    public void Pop()
    {
        _items[GetLastIndex()] = null;
    }

    public bool IsFull()
    {
        int index = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null)
            {
                index++;
            }
        }

        if (index == _items.Length)
        {
            return true;
        }

        return false;
    }

    public bool IsEmpty()
    {
        int index = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                index++;
            }
        }

        if (index == _items.Length)
        {
            return true;
        }

        return false;
    }

}
