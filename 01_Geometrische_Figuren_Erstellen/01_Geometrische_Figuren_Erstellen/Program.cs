using System;
using System.Collections.Generic;
using System.Globalization;

// Basisklasse
abstract class Shape
{
    public string Description { get; set; }
    public abstract double GetVolume();
    public abstract double GetSurface();

    public override string ToString()
    {
        return Description + ", Volumen: " + Math.Round(GetVolume(), 3) + "cm³, " +
               "Oberfläche: " + Math.Round(GetSurface(), 3) + "cm²";
    }
}

// Würfel
class Cube : Shape
{
    public double Side { get; set; }

    public Cube(double side, string desc)
    {
        Side = side;
        Description = desc;
    }

    public override double GetVolume()
    {
        return Math.Pow(Side, 3);
    }

    public override double GetSurface()
    {
        return 6 * Math.Pow(Side, 2);
    }
}

// Quader
class Cuboid : Shape
{
    public double Width, Height, Depth;

    public Cuboid(double w, double h, double d, string desc)
    {
        Width = w;
        Height = h;
        Depth = d;
        Description = desc;
    }

    public override double GetVolume()
    {
        return Width * Height * Depth;
    }

    public override double GetSurface()
    {
        return 2 * (Width * Height + Width * Depth + Height * Depth);
    }
}

// Kugel
class Sphere : Shape
{
    public double Radius { get; set; }

    public Sphere(double r, string desc)
    {
        Radius = r;
        Description = desc;
    }

    public override double GetVolume()
    {
        return 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
    }

    public override double GetSurface()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }
}

// Pyramide
class Pyramid : Shape
{
    public double BaseLength, Height;

    public Pyramid(double b, double h, string desc)
    {
        BaseLength = b;
        Height = h;
        Description = desc;
    }

    public override double GetVolume()
    {
        return (BaseLength * BaseLength * Height) / 3.0;
    }

    public override double GetSurface()
    {
        double slantHeight = Math.Sqrt(Math.Pow(BaseLength / 2, 2) + Math.Pow(Height, 2));
        return (BaseLength * BaseLength) + 2 * BaseLength * slantHeight;
    }
}

// Zylinder
class Cylinder : Shape
{
    public double Radius, Height;

    public Cylinder(double r, double h, string desc)
    {
        Radius = r;
        Height = h;
        Description = desc;
    }

    public override double GetVolume()
    {
        return Math.PI * Math.Pow(Radius, 2) * Height;
    }

    public override double GetSurface()
    {
        return 2 * Math.PI * Radius * (Radius + Height);
    }
}

class Program
{
    static List<Shape> shapes = new List<Shape>();

    static void Main()
    {
        // Beispiel-Formen
        shapes.Add(new Cube(3, "Würfel 1"));
        shapes.Add(new Cuboid(3, 4, 5, "Quader 1"));
        shapes.Add(new Sphere(3, "Kugel 1"));

        int choice = -1;
        while (choice != 0)
        {
            ShowMenu();
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    PrintAll();
                }
                else if (choice == 2)
                {
                    AddShape();
                }
                else if (choice == 3)
                {
                    RemoveShape();
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Programm beendet.");
                }
                else
                {
                    Console.WriteLine("Ungültige Auswahl.");
                }
            }
            else
            {
                Console.WriteLine("Bitte Zahl eingeben.");
            }

            if (choice != 0)
            {
                Console.WriteLine("Weiter mit Taste...");
                Console.ReadKey();
            }
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("1 ... Ausgabe aller Formen");
        Console.WriteLine("2 ... Form hinzufügen");
        Console.WriteLine("3 ... Form entfernen");
        Console.WriteLine("0 ... Programm beenden");
        Console.WriteLine("===============================");
        Console.Write("Menüauswahl: ");
    }

    static void PrintAll()
    {
        for (int i = 0; i < shapes.Count; i++)
        {
            Console.WriteLine(i + ": " + shapes[i]);
        }
    }

    static void AddShape()
    {
        Console.WriteLine("Welche Form?");
        Console.WriteLine("1 ... Würfel");
        Console.WriteLine("2 ... Quader");
        Console.WriteLine("3 ... Kugel");
        Console.WriteLine("4 ... Pyramide");
        Console.WriteLine("5 ... Zylinder");
        Console.Write("Auswahl: ");
        string input = Console.ReadLine();
        int f;
        if (!int.TryParse(input, out f))
        {
            Console.WriteLine("Ungültige Eingabe.");
            return;
        }

        Console.Write("Beschreibung: ");
        string desc = Console.ReadLine();

        if (f == 1)
        {
            Console.Write("Seitenlänge: ");
            double side = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            shapes.Add(new Cube(side, desc));
        }
        else if (f == 2)
        {
            Console.Write("Breite: ");
            double w = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Höhe: ");
            double h = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Tiefe: ");
            double d = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            shapes.Add(new Cuboid(w, h, d, desc));
        }
        else if (f == 3)
        {
            Console.Write("Radius: ");
            double r = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            shapes.Add(new Sphere(r, desc));
        }
        else if (f == 4)
        {
            Console.Write("Grundkante: ");
            double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Höhe: ");
            double ph = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            shapes.Add(new Pyramid(b, ph, desc));
        }
        else if (f == 5)
        {
            Console.Write("Radius: ");
            double cr = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Höhe: ");
            double ch = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            shapes.Add(new Cylinder(cr, ch, desc));
        }
        else
        {
            Console.WriteLine("Ungültige Auswahl.");
        }
    }

    static void RemoveShape()
    {
        PrintAll();
        Console.Write("Index der zu löschenden Form: ");
        string input = Console.ReadLine();
        int idx;
        if (int.TryParse(input, out idx))
        {
            if (idx >= 0 && idx < shapes.Count)
            {
                shapes.RemoveAt(idx);
                Console.WriteLine("Form entfernt.");
            }
            else
            {
                Console.WriteLine("Ungültiger Index.");
            }
        }
        else
        {
            Console.WriteLine("Bitte Zahl eingeben.");
        }
    }
}
