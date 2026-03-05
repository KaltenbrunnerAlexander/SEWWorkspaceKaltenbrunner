using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpEvents
{
    public delegate void NumberUpdate(int number);
    
    class Counter
    {
        public event NumberUpdate CountEvent;

        public int CurrentNumber { get; private set; }

        public void Count()
        {
            for (int i = 0; i < 1000; i++)
            {
                CurrentNumber = i;
                CountEvent.Invoke(CurrentNumber);
                Thread.Sleep(1000);
            }
        }
    }
    class Observer
    {
        public void Update(int number)
        {
            Console.WriteLine(number);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Observer observer = new Observer();

            counter.CountEvent += observer.Update;

            counter.Count();
        }

    }
}
