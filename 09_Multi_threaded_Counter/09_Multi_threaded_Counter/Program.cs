using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Multi_threaded_Counter
{
    class Counter
    {
        static int number;

        public Counter(int number)
        {
            Counter.number = number;
        }

        public void Count()
        {
            for (int i = 0; i < 1000000; i++)
            {
                number++;
            }
        }

        public static int GetNumber()
        {
            return number;
        }   
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter(0);
            Counter counter2 = new Counter(0);

            Task task1 = Task.Run(() => counter1.Count());
            Task task2 = Task.Run(() => counter2.Count());

            Task.WaitAll(task1, task2);

            Console.WriteLine("Final number: " + Counter.GetNumber());

            Console.ReadKey();
        }
    }
}
