using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObserverePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSubject subject = new TimeSubject();

            DaytimeObserver daytimeObserver = new DaytimeObserver();
            subject.Attach(daytimeObserver);

            IntervalObserver intervalObserver = new IntervalObserver();
            subject.Attach(intervalObserver);

            subject.Run();
        }
    }
}
