using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240819_PublisherSubscriberDemo
{
    public class Subscriber: IDisposable
    {
        private Publisher _p;
        private int _allIterationsCount = 0;

        public int AllIterationsCount
        {
            get
            {
                return _allIterationsCount;
            }
        }

        public Subscriber(Publisher p)
        {
            _p = p;
            // _p.Subscribe(IterationCounterHandler);
            _p.NewIteration += IterationCounterHandler;
        }

        public void Dispose()
        {
            //_p.UnSubscribe(IterationCounterHandler);
            _p.NewIteration -= IterationCounterHandler;
        }

        private void IterationCounterHandler(int iteration)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\tSubscriber.IterationCounterHandler({0})", iteration);
            ++_allIterationsCount;
        }
    }
}
