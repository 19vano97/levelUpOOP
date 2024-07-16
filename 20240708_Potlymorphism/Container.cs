namespace _20240708_Potlymorphism;

public class Container
{
    private A[] _items;

    public Container(params A[] items)
    {
        _items = (A[])items.Clone();
    }

    public void DoF2()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].f2();
        }
    }
}
