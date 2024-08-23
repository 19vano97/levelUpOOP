using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240819_PublisherSubscriberDemo
{
    //public delegate void NewIterationDelegate(int iteration);
    public delegate void NewIterationDelegate(object sender, NewIterationEventArgs args);
}
