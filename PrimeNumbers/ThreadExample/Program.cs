using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadExample
{
    internal class Program
    {
        class Counter
        {
            public Counter(ConsoleColor color)
            {
                this.color = color;
            }

            static void Count()
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            Counter counter1 = new Counter(ConsoleColor.Red);
            Counter counter2 = new Counter(ConsoleColor.Green);

            Thread thread1 = new Thread(counter1.Count);
            Thread thread2 = new Thread(counter2.Count);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Count();
        }
    }
}
