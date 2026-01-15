using System.Net.Sockets;
using System.Net;

namespace AsyncChatClient
{
    internal class Program
    {
        // AsyncChatClient "Hallo Welt!"
        static async Task Main(string[] args)
        {
            // Socket = IP-Adresse & Port-Nummer
            TcpClient tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync("127.0.0.1", 5000);

                NetworkStream stream = tcpClient.GetStream();

                string message = "";
                do {
                    Console.Write("Message: ");
                    message = Console.ReadLine();
                    byte[] buffer = System.Text.UTF8Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                } while (message != "quit");
            }
            catch(SocketException sockEx)
            {
                Console.WriteLine("Socket Error! " + sockEx);
            }
        }
    }
}
