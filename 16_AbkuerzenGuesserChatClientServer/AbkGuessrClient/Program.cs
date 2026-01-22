using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AbkGuessrClient
{
    internal class Program
    {
        static async Task Main()
        {
            while (true)
            {
                Console.Write("Abkürzung eingeben: ");
                string eingabe = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(eingabe))
                {
                    TcpClient client = new TcpClient();
                    await client.ConnectAsync("127.0.0.1", 5000);

                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(eingabe);
                    await stream.WriteAsync(data, 0, data.Length);

                    client.Close();
                    Console.WriteLine("Abfrage gesendet");
                }
                else
                {
                    Console.WriteLine("Keine Eingabe");
                }

                Console.Write("Weitere Abkürzung eingeben? (j/n): ");
                string weiter = Console.ReadLine();

                if (weiter.ToLower() != "j")
                    break;
            }

            Console.WriteLine("Client beendet. ENTER drücken.");
            Console.ReadLine();
        }
    }
}
