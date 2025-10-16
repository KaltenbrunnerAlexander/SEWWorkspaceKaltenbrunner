using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _07_Quest_of_the_Dragon
{
    public delegate void AttackAction(Charakter attacker, Charakter target);
    public class Charakter
    {
        public string Name;
        public int Health;
        public int AttackPower;

        public AttackAction NormalerAngriff;
        public AttackAction Heilen;
        public AttackAction SpezialAngriff;

        public Charakter(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;

            NormalerAngriff = NormalAttack;
            Heilen = Heal;
            SpezialAngriff = SpecialAttack;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} - Gesundheit: {Health}, Angriffskraft: {AttackPower}");
        }

        private void NormalAttack(Charakter attacker, Charakter target)
        {
            target.Health = target.Health - attacker.AttackPower;
            if (target.Health < 0) target.Health = 0;

            Console.WriteLine($"{attacker.Name} greift {target.Name} an! {target.Name} verliert {attacker.AttackPower} Lebenspunkte.");
        }

        private void Heal(Charakter attacker, Charakter target)
        {
            attacker.Health = attacker.Health + 10;
            if (attacker.Health > 100) attacker.Health = 100;

            target.Health = target.Health + 5;
            if (target.Health > 100) target.Health = 100;

            Console.WriteLine($"{attacker.Name} heilt sich selbst um 10 Punkte (max 100).");
            Console.WriteLine($"{target.Name} erhält durch die Heilung ebenfalls 5 Punkte.");
        }

        private void SpecialAttack(Charakter attacker, Charakter target)
        {
            target.Health = target.Health - attacker.AttackPower * 2;
            attacker.Health = attacker.Health - 5;

            if (target.Health < 0) target.Health = 0;
            if (attacker.Health < 0) attacker.Health = 0;

            Console.WriteLine($"{attacker.Name} führt einen Spezialangriff aus!");
            Console.WriteLine($"{target.Name} verliert {attacker.AttackPower * 2} Lebenspunkte.");
            Console.WriteLine($"{attacker.Name} verliert selbst 5 Lebenspunkte.");
        }

        public void FuehreAktionAus(Charakter attacker, Charakter target, AttackAction action)
        {
            Console.WriteLine();
            action(attacker, target);
            Console.WriteLine("Aktueller Status");
            attacker.ShowStatus();
            target.ShowStatus();
            Console.WriteLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Charakter held = new Charakter("Held", 100, 20);
            Charakter drache = new Charakter("Drache", 150, 25);

            Console.WriteLine("Der Kampf beginnt!\n");

            held.ShowStatus();
            drache.ShowStatus();

            while (drache.Health > 0 && held.Health > 0)
            {
                Console.WriteLine("\nWähle eine Aktion:");
                Console.WriteLine("1 = Normaler Angriff");
                Console.WriteLine("2 = Heilen");
                Console.WriteLine("3 = Spezialangriff");
                Console.Write("Eingabe: ");
                string input = Console.ReadLine();

                AttackAction gewaehlteAktion = null;

                switch (input)
                {
                    case "1":
                        gewaehlteAktion = held.NormalerAngriff;
                        break;
                    case "2":
                        gewaehlteAktion = held.Heilen;
                        break;
                    case "3":
                        gewaehlteAktion = held.SpezialAngriff;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        continue;
                }

                held.FuehreAktionAus(held, drache, gewaehlteAktion);

                if (drache.Health > 0)
                {
                    Console.WriteLine($"{drache.Name} kontert mit einem Angriff!");
                    drache.FuehreAktionAus(drache, held, drache.NormalerAngriff);
                }

                if (held.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Der Held wurde besiegt! Der Drache gewinnt!");
                    Console.ResetColor();
                    break;
                }

                if (drache.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Der Drache ist besiegt! Der Held gewinnt!");
                    Console.ResetColor();
                    break;
                }
            }

            Console.WriteLine("\n--- Spiel beendet ---");
            Console.ReadKey();
        }
    }
}
