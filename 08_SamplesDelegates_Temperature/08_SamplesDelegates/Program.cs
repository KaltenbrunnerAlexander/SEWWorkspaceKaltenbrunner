using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SamplesDelegates
{
    delegate void TemperatureAlert(double temp);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Temperaturüberwachung im Serverraum – 30 Zufallswerte");
            Console.WriteLine("------------------------------------------------------");

            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                double temp = rnd.NextDouble() * 20 + 20;

                TemperatureAlert alert;

                if (temp >= 30.0)
                    alert = HighTempAlert;
                else
                    alert = NormalTempAlert;

                alert(temp);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Überwachung abgeschlossen.");

            Console.ReadKey();
        }
        static void HighTempAlert(double t)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{t:F1} °C – Achtung! Temperatur über 30 °C!");
            Console.ResetColor();
        }

        static void NormalTempAlert(double t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{t:F1} °C – Temperatur im Normalbereich.");
            Console.ResetColor();
        }
    }
}
