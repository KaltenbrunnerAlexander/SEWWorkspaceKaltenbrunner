using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsnycChatServer
{
    internal class AsyncChatServer
    {

        public async Task ProcessRequest(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            bool runServer = true;
            while (runServer)
            {
                byte[] buffer = new byte[1024];
                int nbBytesRead = await stream.ReadAsync(buffer);

                string msg = UTF8Encoding.UTF8.GetString(buffer, 0, nbBytesRead);

                Console.WriteLine(msg);
            }
        }

        public async Task Run()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
            server.Start();

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                Task t = ProcessRequest(client);
            }
        }
    }
}
