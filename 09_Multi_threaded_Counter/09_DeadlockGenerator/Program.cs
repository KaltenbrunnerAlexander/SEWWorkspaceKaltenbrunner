using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;


namespace _09_DeadlockGenerator
{
    class Program
    {
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Thread threadA = new Thread(ActionA);
            Thread threadB = new Thread(ActionB);

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();

            

            Console.WriteLine("Programm beendet."); 

        }
        static void ActionA()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("ActionA: Waiting ...");
                DelayRandom(500, 1000);

                lock (lockObject)
                {
                    Console.WriteLine("ActionA: Got lock on file system.");
                    DelayRandom(500, 1000);
                    Console.WriteLine("ActionA: Release locks.");
                }
            }
        }
        static void ActionB()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("ActionB: Waiting ...");
                DelayRandom(500, 1000);

                lock (lockObject)
                {
                    Console.WriteLine("ActionB: Got lock on file system.");
                    DelayRandom(500, 1000);
                    Console.WriteLine("ActionB: Release locks.");
                }
            }
        }
        static void DelayRandom(int minMilliseconds, int maxMilliseconds)
        {
            Random random = new Random();
            int waitTime = random.Next(minMilliseconds, maxMilliseconds + 1);
            Thread.Sleep(waitTime);
        }
    }
}
