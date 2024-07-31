namespace _20240729_Lesson_Iterator;

public struct ContainerIterator2
{
    private IContainer _source;
    private int _position;
    public ContainerIterator2(IContainer source)
    {
        _source = source;
        _position = -1;
    }
    public object Current
    {
        get
        {
            return _source[_position];
        }
    }
    public bool MoveNext()
    {
        ++_position;
        bool ok = _position < _source.Size;
        return ok;
    }
    public void Reset()
    {
        _position = -1;
    }
}
