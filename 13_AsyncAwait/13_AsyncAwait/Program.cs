using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _13_AsyncAwait
{
    internal class Program
    {
        public static int Count(int start)
        {
            int number = start;
            for(;number < start + 10; number++)
            {
                Console.WriteLine("Counting:" + number);
                Thread.Sleep(500);
            }
            return number;
        }

        public static void CountTwiceSync()
        {
            int countedNumber1 = Count(1);
            int countedNumber2 = Count(37);
            Console.WriteLine("Ergebnis 1: " + countedNumber1);
            Console.WriteLine("Ergebnis 2: " + countedNumber2);
        }

        public static async Task<int> CountAsync(int start)
        {
            int number = start;
            for (; number < start + 10; number++)
            {
                Console.WriteLine("Counting:" + number);
                Task t = Task.Delay(500);
                await t;
            }
            return number;
        }

        public static async Task CountTwiceAsync()
        {
            int countedNumber1 = await CountAsync(1);
            int countedNumber2 = await CountAsync(37);
            Console.WriteLine("Ergebnis 1: " + countedNumber1);
            Console.WriteLine("Ergebnis 2: " + countedNumber2);
        }
        public static void Main(string[] args)
        {
            CountTwiceSync();
            CountTwiceAsync().Wait();
        }
    }
}
