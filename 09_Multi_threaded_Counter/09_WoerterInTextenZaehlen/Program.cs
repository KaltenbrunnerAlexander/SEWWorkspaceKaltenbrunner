using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;

namespace _09_WoerterInTextenZaehlen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urls = new string[]
            {
                "https://www.gutenberg.org/files/1342/1342-0.txt", // Pride and Prejudice
                "https://www.gutenberg.org/files/11/11-0.txt", // Alice's Adventures in Wonderland
                "https://www.gutenberg.org/files/84/84-0.txt", // Frankenstein
                //"https://www.gutenberg.org/files/2701/2701/2701-h.htm", // Moby Dick by Herman Melville
                "https://www.gutenberg.org/files/2600/2600-h/2600-h.htm", // War and Peace by Leo Tolstoy
                "https://www.gutenberg.org/files/1342/1342-h/1342-h.htm", // Pride and Prejudice by Jane Austen
                "https://www.gutenberg.org/files/28054/28054-h/28054-h.htm", // The Brothers Karamazov by Fyodor Dostoyevsky
                "https://www.gutenberg.org/files/1399/1399-h/1399-h.htm", // Anna Karenina by Leo Tolstoy
                "https://www.gutenberg.org/files/2554/2554-h/2554-h.htm", // Crime and Punishment by Fyodor Dostoyevsky
                "https://www.gutenberg.org/files/1184/1184-h/1184-h.htm", // The Count of Monte Cristo by Alexandre Dumas
                "https://www.gutenberg.org/files/996/996-h/996-h.htm", // Don Quixote by Miguel de Cervantes
                "https://www.gutenberg.org/files/135/135-h/135-h.htm", // Les Misérables by Victor Hugo
                "https://www.gutenberg.org/files/145/145-h/145-h.htm" // Middlemarch by George Eliot
            };

            Console.WriteLine("Single-Threaded Variante:");
            SingleThreadedWordCounter(urls, "the");
        }
        static void SingleThreadedWordCounter(string[] urls, string word)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int totalCount = 0;

            foreach (string url in urls)
            {
                using (HttpClient client = new HttpClient())
                {
                    string pageContent = client.GetStringAsync(url).Result;
                    int count = CountWordOccurrences(pageContent, word);
                    Console.WriteLine($"URL: {url} - Vorkommen von '{word}': {count}");
                    totalCount += count;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Gesamtanzahl von '{word}': {totalCount}");
            Console.WriteLine($"Ausführungszeit: {stopwatch.ElapsedMilliseconds} ms");
        }

        static int CountWordOccurrences(string text, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }
    }
}
