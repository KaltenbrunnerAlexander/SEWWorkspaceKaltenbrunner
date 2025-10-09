using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Net.Configuration;

namespace _05_Formatted_Logger
{
    internal class Program
    {
        private static int maxLength = 0;
        public static string FormatAddDateTime(string s)
        {
            return $"{DateTime.Now}: {s}";
        }

        public static string FormatUpperCase(string s)
        {
            return s.ToUpper();
        }

        public static void SetLengthLimit(int length)
        {
            maxLength = length;
        }

        public static string FormatLengthLimited(string s)
        {
            return s.Length > maxLength ? s.Substring(0, maxLength) + "..." : s;
        }

        static void Main(string[] args)
        {
            Logging logEntry = new Logging();

            
            logEntry.AddLogMessage("System not found");
            logEntry.AddLogMessage("User not found");
            logEntry.AddLogMessage("File not found");

            Console.WriteLine("Original");
            logEntry.PrintMessage(null);

            Console.WriteLine("\nFormat with DateTime");
            logEntry.PrintMessage(FormatAddDateTime);

            Console.WriteLine("\nFormat with UpperCase");
            logEntry.PrintMessage(FormatUpperCase);

            Console.WriteLine("\nFormat with a Length Limit");
            SetLengthLimit(30);
            logEntry.PrintMessage(FormatLengthLimited);

            Console.ReadKey();

        }
    }
    class Logging
    {
        private List<string> logMessages = new List<string>();
        public void AddLogMessage(string msg)
        {
            logMessages.Add(msg);
        }

        public void PrintMessage(Func<string, string> formattingFunc)
        {
            foreach (var msg in logMessages)
            {
                string formatted;

                if (formattingFunc != null)
                    formatted = formattingFunc(msg);
                else
                    formatted = msg;

                Console.WriteLine(formatted);
            }
        }

        
    }
}
