using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObserverePattern
{
    internal class IntervalObserver : Observer
    {
        public override void Update(Subject subject)
        {
            if (subject is TimeSubject s)
            {
                if(s.Time.Second % 6 < 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("IntervalObserver");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("IntervalObserver");
                }
                Console.ResetColor();
            }
        }
    }
}
