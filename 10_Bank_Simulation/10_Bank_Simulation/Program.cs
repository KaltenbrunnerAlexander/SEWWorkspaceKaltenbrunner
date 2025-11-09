using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_Bank_Simulation
{
    public class BankAccount
    {
        public string AccountNumber;
        public double Balance;
        private object lockObject = new object();

        public BankAccount(string number, double startBalance)
        {
            AccountNumber = number;
            Balance = startBalance;
        }

        public void Deposit(double amount)
        {
            lock (lockObject)
            {
                Balance = Balance + amount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(AccountNumber + ":" + " Einzahlung " + amount + " Neuer Kontostand " + Balance);
                Console.ResetColor();
            }
        }

        public void Withdraw(double amount)
        {
            lock (lockObject)
            {
                if (Balance >= amount)
                {
                    Balance = Balance - amount;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(AccountNumber + ":" + " Abhebung: " + amount + " Neuer Kontostand: " + Balance);
                    Console.ResetColor();
                }
            }
        }

        public void Transfer(BankAccount target, double amount)
        {
            BankAccount first = this;
            BankAccount second = target;

            if (first.AccountNumber.CompareTo(second.AccountNumber) > 0)
            {
                first = target;
                second = this;
            }

            lock (first.lockObject)
            {
                lock (second.lockObject)
                {
                    if (Balance >= amount)
                    {
                        Balance = Balance - amount;
                        target.Balance = target.Balance + amount;
                        Console.WriteLine("Überweisung von " + AccountNumber + " an " + target.AccountNumber + ": " + amount);
                    }
                }
            }
        }
    }

    public class Program
    {
        static Random random = new Random();
        static double totalDeposits = 0;
        static double totalWithdrawals = 0;
        static object totalLock = new object();

        public static void Main()
        {
            List<BankAccount> konten = new List<BankAccount>();
            double startSum = 0;

            for (int i = 1; i < 11; i++)
            {
                double start = random.Next(500, 2000);
                BankAccount konto = new BankAccount("Konto" + i, start);
                konten.Add(konto);
                startSum = startSum + start;
            }

            Console.WriteLine("Startsumme " + startSum);

            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(new ThreadStart(() => Aktionen(konten)));
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            double endSum = 0;
            for (int i = 0; i < konten.Count; i++)
            {
                endSum = endSum + konten[i].Balance;
            }

            double expectedSum = startSum + totalDeposits - totalWithdrawals;

            Console.WriteLine("Endsumme " + endSum);
            Console.WriteLine("Erwartete Summe " + expectedSum);

            if (Math.Abs(endSum - expectedSum) < 0.01)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Konsistenz in Ordnung");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Fehlerhafte Konsistenz");
                Console.ResetColor();
            }
        }

        static void Aktionen(List<BankAccount> konten)
        {
            for (int i = 0; i < 20; i++)
            {
                int aktion = random.Next(3);
                int index1 = random.Next(konten.Count);
                BankAccount konto1 = konten[index1];

                if (aktion == 0)
                {
                    double betrag = random.Next(50, 300);
                    konto1.Deposit(betrag);
                    lock (totalLock)
                    {
                        totalDeposits = totalDeposits + betrag;
                    }
                }
                else if (aktion == 1)
                {
                    double betrag = random.Next(50, 300);
                    konto1.Withdraw(betrag);
                    lock (totalLock)
                    {
                        totalWithdrawals = totalWithdrawals + betrag;
                    }
                }
                else
                {
                    int index2 = random.Next(konten.Count);
                    while (index2 == index1)
                    {
                        index2 = random.Next(konten.Count);
                    }

                    BankAccount konto2 = konten[index2];
                    double betrag = random.Next(50, 300);
                    konto1.Transfer(konto2, betrag);
                }

                Thread.Sleep(random.Next(50, 200));
            }
        }
    }
}
