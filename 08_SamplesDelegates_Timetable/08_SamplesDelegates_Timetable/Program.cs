using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SamplesDelegates_Timetable
{
    enum Subject
    {
        SEW, INSY, SYT, M, D, E, NWT, NW2, GGP, PH, BESP, FIT, CCIT, KPT, WIR, RK, ETH, ITP, PAUSE, ENDE, SUPPL
    }

    delegate Subject SubjectSelector(int stunde, string tag);

    internal class Program
    {
        static Random rnd = new Random();
        static string[] tage = { "Mo", "Di", "Mi", "Do", "Fr" };
        static int maxStunden = 10;
        static int rrIndex = 0;
        static void Main(string[] args)
        {
            var plan = new Dictionary<string, Subject[]>
            {
                ["Mo"] = new[] { Subject.GGP, Subject.NW2, Subject.E, Subject.E, Subject.BESP, Subject.WIR, Subject.ENDE, Subject.ENDE, Subject.ENDE, Subject.ENDE },
                ["Di"] = new[] { Subject.CCIT, Subject.CCIT, Subject.ITP, Subject.ITP, Subject.INSY, Subject.PAUSE, Subject.ITP, Subject.ITP, Subject.ITP, Subject.ITP },
                ["Mi"] = new[] { Subject.INSY, Subject.INSY, Subject.SYT, Subject.SYT, Subject.CCIT, Subject.CCIT, Subject.ENDE, Subject.ENDE, Subject.ENDE, Subject.ENDE },
                ["Do"] = new[] { Subject.M, Subject.M, Subject.KPT, Subject.WIR, Subject.NW2, Subject.GGP, Subject.PAUSE, Subject.SEW, Subject.SEW, Subject.SEW },
                ["Fr"] = new[] { Subject.RK, Subject.RK, Subject.D, Subject.D, Subject.INSY, Subject.INSY, Subject.ENDE, Subject.ENDE, Subject.ENDE, Subject.ENDE }
            };

            Console.WriteLine("Normaler Stundenplan:");
            PrintPlan(plan);

            Console.WriteLine("Drücke eine Taste, um 5 zufällige SUPPL-Stunden zu setzen...");
            Console.ReadKey();
            RandomSuppl(plan, 5);
            Console.WriteLine("Stundenplan mit SUPPL-Stunden:");
            PrintPlan(plan);

            Console.WriteLine("Wähle Strategie: 1=Zufall, 2=Round-Robin, 3=Regelbasiert");
            int wahl = int.Parse(Console.ReadLine() ?? "1");

            SubjectSelector selector;

            switch (wahl)
            {
                case 1:
                    selector = ZufallStrategy;
                    break;
                case 2:
                    selector = RoundRobinStrategy;
                    break;
                case 3:
                    selector = RegelStrategy;
                    break;
                default:
                    selector = ZufallStrategy;
                    break;
            }

            ApplyStrategy(plan, selector);

            Console.WriteLine("Neuer Stundenplan nach Strategie:");
            PrintPlan(plan);

        }

        static void PrintPlan(Dictionary<string, Subject[]> plan)
        {
            Console.Write("Stunde\t");
            foreach (var tag in tage)
                Console.Write(tag + "\t");
            Console.WriteLine();

            for (int stunde = 0; stunde < maxStunden; stunde++)
            {
                Console.Write((stunde + 1) + "\t");
                foreach (var tag in tage)
                {
                    SetColor(plan[tag][stunde]);
                    Console.Write(plan[tag][stunde] + "\t");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void SetColor(Subject subj)
        {
            switch (subj)
            {
                case Subject.SEW: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case Subject.INSY: Console.ForegroundColor = ConsoleColor.Green; break;
                case Subject.SYT: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case Subject.M: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case Subject.D: Console.ForegroundColor = ConsoleColor.Blue; break;
                case Subject.E: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case Subject.NWT: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case Subject.NW2: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case Subject.GGP: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                case Subject.PH: Console.ForegroundColor = ConsoleColor.Gray; break;
                case Subject.BESP: Console.ForegroundColor = ConsoleColor.White; break;
                case Subject.CCIT: Console.ForegroundColor = ConsoleColor.Red; break;
                case Subject.KPT: Console.ForegroundColor = ConsoleColor.Blue; break;
                case Subject.WIR: Console.ForegroundColor = ConsoleColor.Green; break;
                case Subject.RK: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case Subject.ITP: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case Subject.PAUSE: Console.ForegroundColor = ConsoleColor.Gray; break;
                case Subject.ENDE: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case Subject.SUPPL: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                default: Console.ResetColor(); break;
            }
        }


        static void RandomSuppl(Dictionary<string, Subject[]> plan, int count)
        {
            for (int i = 0; i < count; i++)
            {
                string tag = tage[rnd.Next(tage.Length)];
                int stunde = rnd.Next(maxStunden);
                plan[tag][stunde] = Subject.SUPPL;
            }
        }

        static void ApplyStrategy(Dictionary<string, Subject[]> plan, SubjectSelector strategy)
        {
            foreach (var tag in tage)
            {
                for (int i = 0; i < maxStunden; i++)
                {
                    if (plan[tag][i] == Subject.SUPPL)
                        plan[tag][i] = strategy(i, tag);
                }
            }
        }

        static Subject ZufallStrategy(int stunde, string tag)
        {
            Array values = Enum.GetValues(typeof(Subject));
            return (Subject)values.GetValue(rnd.Next(values.Length - 3)); // ohne PAUSE/ENDE/SUPPL
        }

        static Subject RoundRobinStrategy(int stunde, string tag)
        {
            Array values = Enum.GetValues(typeof(Subject));
            Subject subj = (Subject)values.GetValue(rrIndex % (values.Length - 3));
            rrIndex++;
            return subj;
        }

        static Subject RegelStrategy(int stunde, string tag)
        {
            if (stunde < 5)
            {
                Subject[] vormittag = { Subject.SEW, Subject.INSY, Subject.SYT, Subject.NWT };
                return vormittag[rnd.Next(vormittag.Length)];
            }
            else
            {
                Subject[] nachmittag = { Subject.D, Subject.E, Subject.M };
                return nachmittag[rnd.Next(nachmittag.Length)];
            }
        }
    }
}
