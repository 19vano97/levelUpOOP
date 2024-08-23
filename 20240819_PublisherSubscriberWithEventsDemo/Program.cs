using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240819_PublisherSubscriberDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher p1 = new Publisher();

            Subscriber s1 = new Subscriber(p1);

            p1.Run();

            Console.WriteLine();
            Console.WriteLine("-==-=-=-=--=-=-=-=- -==-=-=-=--=-=-=-=- ");
            Console.WriteLine();

            //p1.Subscribe(NewIterationStaticHanler1);
            p1.NewIteration += NewIterationStaticHanler1;

            p1.Run();

            Console.WriteLine();
            Console.WriteLine("-==-=-=-=--=-=-=-=- -==-=-=-=--=-=-=-=- ");
            Console.WriteLine();

            //p1.Subscribe(NewIterationStaticHanler2);
            p1.NewIteration += NewIterationStaticHanler2;

            p1.Run();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("AllIterationsCount: {0}", s1.AllIterationsCount);
            Console.WriteLine();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        // обробники події 
        public static void NewIterationStaticHanler1(int iteration)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tNewIterationStaticHanler1({0})", iteration);
        }

        public static void NewIterationStaticHanler2(int iteration)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\tNewIterationStaticHanler2({0})", iteration);
        }
    }
}
