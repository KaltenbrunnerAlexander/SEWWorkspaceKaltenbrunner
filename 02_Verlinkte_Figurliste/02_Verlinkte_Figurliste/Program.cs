using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Verlinkte_Figurliste
{
    interface IFigur
    {
        double berechneOberflaeche();
        double berechneVolumen();
    }

    abstract class Figur : IFigur
    {
        public Figur next = null;
        public Figur(string beschreibung)
        {
            Beschreibung = beschreibung;
        }

        public string Beschreibung { get; }

        public abstract double berechneOberflaeche();
        public abstract double berechneVolumen();
    }

    class Kugel : Figur
    {
        public double Radius { get; }

        public Kugel(string beschreibung, double radius) : base(beschreibung)
        {
            Radius = radius;
        }

        public override double berechneOberflaeche()
        {
            return 4.0 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double berechneVolumen()
        {
            return (4.0 * Math.PI * Math.Pow(Radius, 3)) / 3.0;
        }
    }

    class Wuerfel : Figur
    {
        public double Seitenlaenge { get; }

        public Wuerfel(string beschreibung, double a) : base(beschreibung)
        {
            Seitenlaenge = a;
        }

        public override double berechneOberflaeche()
        {
            return 6.0 * Math.Pow(Seitenlaenge, 2);
        }

        public override double berechneVolumen()
        {
            return Math.Pow(Seitenlaenge, 3);
        }
    }
    class VerlinkteFigurListe
    {
        Figur firstElement = null;

        public int Count { get; private set; } = 0;  // <<< hinzugefügt

        public VerlinkteFigurListe()
        {
        }

        public void Add(Figur newElement)
        {
            newElement.next = firstElement;
            firstElement = newElement;
            Count++;   // <<< Counter erhöhen
        }

        public void AusgabeAllerFiguren()
        {
            Figur aktuelleFigur = firstElement;

            while (aktuelleFigur != null)
            {
                Console.WriteLine($"{aktuelleFigur.Beschreibung} " +
                    $"Oberfläche: {aktuelleFigur.berechneOberflaeche()} " +
                    $"Volumen: {aktuelleFigur.berechneVolumen()}");  // <<< Volumen ergänzt
                aktuelleFigur = aktuelleFigur.next;
            }
        }

        public Figur Pop()
        {
            Figur temp = firstElement;
            if (firstElement != null)
            {
                firstElement = firstElement.next;
                Count--;   // <<< Counter verringern
            }
            return temp;
        }

        public Figur PopLast()
        {
            if (firstElement == null) return null;
            if (firstElement.next == null)
            {
                Figur temp = firstElement;
                firstElement = null;
                Count--;   // <<< Counter verringern
                return temp;
            }
            Figur aktuelleFigur = firstElement;
            while (aktuelleFigur.next.next != null)
            {
                aktuelleFigur = aktuelleFigur.next;
            }
            Figur last = aktuelleFigur.next;
            aktuelleFigur.next = null;
            Count--;   // <<< Counter verringern
            return last;
        }

        // <<< Entfernen nach Index
        public void Remove(int index)
        {
            if (index < 0 || index >= Count) return;

            if (index == 0)
            {
                Pop();
                return;
            }

            Figur aktuelleFigur = firstElement;
            for (int i = 0; i < index - 1; i++)
            {
                aktuelleFigur = aktuelleFigur.next;
            }

            aktuelleFigur.next = aktuelleFigur.next?.next;
            Count--;
        }

        // <<< Entfernen nach Referenz
        public void Remove(Figur figur)
        {
            if (firstElement == null) return;

            if (firstElement == figur)
            {
                Pop();
                return;
            }

            Figur aktuelleFigur = firstElement;
            while (aktuelleFigur.next != null && aktuelleFigur.next != figur)
            {
                aktuelleFigur = aktuelleFigur.next;
            }

            if (aktuelleFigur.next == figur)
            {
                aktuelleFigur.next = figur.next;
                Count--;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            VerlinkteFigurListe liste = new VerlinkteFigurListe();

            Kugel k1 = new Kugel("K1", 10);
            liste.Add(new Kugel("K2", 8));
            liste.Add(new Wuerfel("W1", 3));
            liste.Add(new Wuerfel("W2", 4));
            liste.Add(k1);
            Console.WriteLine("Letzte gelöschte Element: " + liste.Pop().Beschreibung);
            Console.WriteLine("Letzte gelöschte Element in der Liste: " + liste.PopLast().Beschreibung);
            liste.Remove(1);
            liste.Remove(k1);
            Console.WriteLine($"Anzahl der Elemente in der Liste: {liste.Count}");

            liste.AusgabeAllerFiguren(); // Gibt alle Figuren mit Bezeichnung, Oberfläche und Volumen auf der Konsole aus

            Console.ReadKey();
        }
    }
}
