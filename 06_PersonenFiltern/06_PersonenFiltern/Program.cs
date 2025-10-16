using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_PersonenFiltern
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Geburtsjahr { get; set; }

        public Person(string vorname, string nachname, int geburtsjahr)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsjahr = geburtsjahr;
        }
        public override string ToString()
        {
            return Vorname + " " + Nachname + ", geboren " + Geburtsjahr;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> PersonList = new List<Person>()
            {
                new Person("Max", "Mustermann", 1980),
                new Person("Erika", "Musterfrau", 2007),
                new Person("Hans", "Schmidt", 1975),
                new Person("Anna", "Schneider", 2001),
                new Person("Alex", "Fischer", 1985)
            };

            List<Person> personenMitA = PersonList.FindAll(StartetMitA);
            foreach (Person p in personenMitA)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            List<Person> personenNach2000 = PersonList.FindAll(GeborenNach2000);
            foreach (Person p in personenNach2000)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }

        static bool StartetMitA(Person p)
        {
            return p.Vorname.StartsWith("A");
        }

        static bool GeborenNach2000(Person p)
        {
            return p.Geburtsjahr > 2000;
        }

    }
}

