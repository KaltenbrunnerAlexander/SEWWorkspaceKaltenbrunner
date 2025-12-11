using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleChat
{
    internal class ChatClient
    {
        private int port;
        private MainWindow mainwindow;
        private Socket socket;

        public ChatClient(int port, MainWindow mainwindow)
        {
            this.port = port;
            this.mainwindow = mainwindow;

            IPEndPoint endPoint = new IPEndPoint(
                IPAddress.Loopback, port);

            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            socket.Connect(endPoint);
        }

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            socket.Send(buffer);
        }
    }
}
