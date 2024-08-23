using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240819_PublisherSubscriberDemo
{
    public class Publisher
    {
        const int DEFAULT_ITERATIONS_COUNT = 10;

        private int _iterationsCount;

        private NewIterationDelegate _newIterationHandlers;    // ланцюжок викликів методів, "яким цікава" нова ітерація

        //public void Subscribe(NewIterationDelegate handler)
        //{
        //    _newIterationHandlers += handler;
        //}

        //public void UnSubscribe(NewIterationDelegate handler)
        //{
        //    _newIterationHandlers -= handler;
        //}

        public event NewIterationDelegate NewIteration
        {
            add
            {
                _newIterationHandlers += value;
            }
            remove
            {
                _newIterationHandlers -= value;
            }
        }

        public Publisher(int iterationsCount = DEFAULT_ITERATIONS_COUNT)
        {
            _iterationsCount = iterationsCount;
        }

        public void Run()
        {
            for (int i = 0; i < _iterationsCount; i++)
            {
                if (_newIterationHandlers != null) 
                {
                    _newIterationHandlers(i);    // повідомлення підписників що сталася нова ітерація
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Run(), i = {0}", i);
            }
        }
    }
}
