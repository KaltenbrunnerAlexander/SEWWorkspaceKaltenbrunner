using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleChat
{
    internal class ChatServer
    {
        private int port;
        MainWindow win;
        private Thread thread;

        public ChatServer(int port, MainWindow win)
        {
            this.port = port;
            this.win = win;
        }

        public void Start()
        {
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            Socket server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            server.Bind(endPoint);
            server.Listen(10);

            Socket client = server.Accept(); // blockierend

            byte[] buffer = new byte[1024];
            client.Receive(buffer); // blockierend

            string msg = Encoding.UTF8.GetString(buffer).Trim('\0');

            win.Dispatcher.Invoke(() =>
            {
                win.lst_receiveMessage.Items.Add(msg);
            });

            client.Shutdown(SocketShutdown.Both);
            client.Close();
            server.Close();
        }
    }
}
