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
            TcpClient client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 5000);

            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("ca");

            await stream.WriteAsync(data, 0, data.Length);

            client.Close();
        }
    }
}
