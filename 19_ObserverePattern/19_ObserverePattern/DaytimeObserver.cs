using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ObserverePattern
{
    internal class DaytimeObserver : Observer
    {
        public override void Update(Subject subject)
        {
            if(subject is TimeSubject s)
            {
                DateTime time = s.Time;
                if (time.Hour > 6 && time.Hour < 18)
                    Console.WriteLine("Daytime Observer: Tag");
                else
                    Console.WriteLine("Daytime Observer: Nacht");
            }
        }
    }
}
