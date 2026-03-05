using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _19_ObserverePattern
{
    internal class TimeSubject : Subject
    {
        public DateTime Time { get; set; }


        public void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Time = DateTime.Now;
                Notify();
                Thread.Sleep(1000);
            }
        }
    }
}
