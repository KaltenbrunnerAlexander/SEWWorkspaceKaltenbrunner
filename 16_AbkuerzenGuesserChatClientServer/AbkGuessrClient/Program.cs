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
            try
            {
                Console.Write("Abkürzung eingeben: ");
                string eingabe = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(eingabe))
                {
                    Console.WriteLine("Keine Eingabe!");
                    Console.ReadLine();
                    return;
                }

                TcpClient client = new TcpClient();
                await client.ConnectAsync("127.0.0.1", 5000);

                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(eingabe);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                string antwort = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Server: " + antwort);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CLIENT FEHLER:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Drücke ENTER zum Beenden");
            Console.ReadLine();
        }
    }
}
