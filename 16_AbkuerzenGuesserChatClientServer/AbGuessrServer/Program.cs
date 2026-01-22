using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AbkGuessrServer
{
    internal class Program
    {
        static Dictionary<string, string> dictionary;

        static async Task Main()
        {
            dictionary = new Dictionary<string, string>();

            foreach (string line in File.ReadAllLines("abkuerzungen.txt"))
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                    dictionary[parts[0]] = parts[1];
            }

            TcpListener listener = new TcpListener(IPAddress.Loopback, 5000);
            listener.Start();
            Console.WriteLine("Server läuft...");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                HandleClientAsync(client);
            }
        }

        static async void HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string abkuerzung = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                string antwort;
                if (dictionary.ContainsKey(abkuerzung))
                    antwort = dictionary[abkuerzung];
                else
                    antwort = "Abkürzung nicht gefunden";

                byte[] response = Encoding.UTF8.GetBytes(antwort);
                await stream.WriteAsync(response, 0, response.Length);
            }
        }
    }
}
