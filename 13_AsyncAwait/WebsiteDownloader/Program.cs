using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsiteDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            List<string> urls = new List<string>();
            urls.Add("https://www.google.com");
            urls.Add("https://www.youtube.com");
            urls.Add("https://www.orf.at");
            urls.Add("https://www.facebook.com");
            urls.Add("https://www.amazon.de");
            urls.Add("https://www.instagram.com");

            string longestWebsite = calculateLongest(urls).Result;
            Console.WriteLine(longestWebsite);
            */

            Console.ReadKey();
            Task[] tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                Task t = PrintDelayed($"Hallo {i}", 1000 + i * 1000);
                tasks[i] = t;
            }
            Task.WaitAll(tasks);

        }

        public static async Task PrintDelayed(string text, int delTime)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId
                + ": A " + text);
            await Task.Delay(delTime);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId
                + ": B " + text);
        }
        /*private static async Task<string> calculateLongest(List<string> urls)
        {
            HttpClient client = new HttpClient();
            Task<string> task1 = client.GetStringAsync(urls[0]);
            Task<string> task2 = client.GetStringAsync(urls[1]);
            Task<string> task3 = client.GetStringAsync(urls[2]);
            string website1 = await task1;
            string website2 = await task2;
            string website3 = await task3;



            if (website1.Length > website2.Length && website1.Length > website3.Length)
            {
                return urls[0];
            }
            else if (website2.Length > website1.Length && website2.Length > website3.Length)
            {
                return urls[1];
            }
            else 
            {
                return urls[2];
            }
            return "";
        }*/

    }
}
