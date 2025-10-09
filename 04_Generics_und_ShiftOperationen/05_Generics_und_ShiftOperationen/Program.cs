using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Generics_und_ShiftOperationen
{
    
    class Node<T>
    {
        public T Value;
        public Node<T> next;
        public Node(T value)
        {
            Value = value;
        }
    }
    class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }
        public void Shift(int x)
        {
            Node<T> newStart = head;
            for(int i = 0; i < x; i++)
            {
                if (newStart != null)
                    newStart = newStart.next;
            }

            Node<T> oldStart = head;
            head = newStart;

            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> current = head;
            while (current != null)
            {
                sb.Append(current.Value + " ");
                current = current.next;
            }
            return sb.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           

            LinkedList<string> list = new LinkedList<string>();

            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");

            Console.WriteLine("Liste bevor Shift: ");
            
        }
    }
}
