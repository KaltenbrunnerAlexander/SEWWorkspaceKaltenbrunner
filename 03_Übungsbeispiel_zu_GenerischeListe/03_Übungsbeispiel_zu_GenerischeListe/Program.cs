using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Übungsbeispiel_zu_GenerischeListe
{
    interface ISelector
    {
        bool Select(object obj);
    }

    class GenericList
    {
        private ListEntry firstEntry;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public void Add(object data)
        {
            ListEntry newEntry = new ListEntry();
            newEntry.data = data;

            newEntry.next = firstEntry;
            firstEntry = newEntry;
            count++;
        }
        public void Ausgabe()
        {
            ListEntry current = firstEntry;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        public object Pop()
        {
            if (firstEntry == null) return null;

            object data = firstEntry.data;
            firstEntry = firstEntry.next;
            count--;
            return data;
        }

        public object FindFirst(ISelector selector)
        {
            ListEntry current = firstEntry;
            while (current != null)
            {
                if (selector.Select(current.data))
                {
                    return current.data;
                }
                current = current.next;
            }
            return null;
        }

        public GenericList FindAll(ISelector selector)
        {
            GenericList result = new GenericList();
            ListEntry current = firstEntry;
            while (current != null)
            {
                if (selector.Select(current.data))
                {
                    result.Add(current.data);
                }
                current = current.next;
            }
            return result;
        }

        public void Remove(ISelector selector)
        {
            ListEntry current = firstEntry;
            ListEntry previous = null;

            while (current != null)
            {
                if (selector.Select(current.data))
                {
                    if (previous == null)
                    {
                        firstEntry = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                    count--;
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }
        }
    }
    class ListEntry
    {
        public ListEntry next;
        public object data;
    }

    class StringSelector : ISelector
    {
        public bool Select(object obj)
        {
            return obj is string;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList myList = new GenericList();
            myList.Add("Hallo");
            myList.Add(345.5);
            myList.Add(new { name = "Dagobert", alter = 70 });
            Console.WriteLine("Alle Elemente:");
            myList.Ausgabe();

            Console.WriteLine("\nPop: " + myList.Pop());
            Console.WriteLine("Nach Pop:");
            myList.Ausgabe();

            Console.WriteLine("\nAnzahl: " + myList.Count);

            object firstString = myList.FindFirst(new StringSelector());
            Console.WriteLine("\nErster String: " + firstString);

            GenericList allStrings = myList.FindAll(new StringSelector());
            Console.WriteLine("\nAlle Strings:");
            allStrings.Ausgabe();

            myList.Remove(new StringSelector());
            Console.WriteLine("\nListe nach Remove (Strings entfernt):");
            myList.Ausgabe();

            Console.ReadKey();
        }
    }
}