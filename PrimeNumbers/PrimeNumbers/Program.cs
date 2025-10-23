using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    internal class Program
    {
        bool isPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        // PrimeNumbers.exe 1000000 1100000
        //Ausgabe:
        // Primzahlen von 1000000 bis 1100000
        static void Main(string[] args)
        {
            Console.WriteLine($"Primzahlen von {args[0]} bis {args[1]}");

            int start = int.Parse(args[0]);
            int ende = int.Parse(args[1]);

            for (int i = start; i <= ende; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }   
            }
        }
    }
}
