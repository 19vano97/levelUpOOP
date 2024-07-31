using System.Collections;

namespace _20240729_Lesson_Iterator;

public class Container: IContainer, IEnumerable
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

        #region IEnumerable

        // (3)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        // (2)
        //public IEnumerator GetEnumerator()
        //{
        //    return new ContainerIterator2(this);
        //}

        // (1)
        //public IEnumerator GetEnumerator()
        //{
        //    return new ContainerIterator(this);
        //}

        #endregion


        #region IEnumerable

        private struct ContainerIterator : IEnumerator
        {
           private Container _source;
           private int _position;

           public ContainerIterator(Container source)
           {
               _source = source;
               _position = -1;
           }

           public object Current
           {
               get 
               {
                   return _source._items[_position];
               }
           }

           public bool MoveNext()
           {
               ++_position;

               bool ok = _position < _source._items.Length;

               return ok;
           }

           public void Reset()
           {
               _position = -1;
           }
        }

        #endregion
    }