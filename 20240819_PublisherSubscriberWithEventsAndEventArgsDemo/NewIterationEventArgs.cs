using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240819_PublisherSubscriberDemo
{
    public class NewIterationEventArgs: EventArgs
    {
        public int Iteration { get; private set; }

        public NewIterationEventArgs(int i)
        {
            Iteration = i; 
        }
    }
}
