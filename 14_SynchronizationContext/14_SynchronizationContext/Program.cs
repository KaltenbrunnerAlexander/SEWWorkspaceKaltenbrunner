using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _14_SynchronizationContext
{
    internal class Program
    {
        static async Task<int> Add(int x, int y)
        {
            Console.WriteLine("Current Thread before: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Current Thread after: " + Thread.CurrentThread.ManagedThreadId);
            return x + y;
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine("Initial Thread: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Start");
            int a = 10;
            int b = 15;
            int result = Add(a, b).Result;
            Console.WriteLine(result);
            Console.WriteLine("Current Thread at End: " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }
    }
}
