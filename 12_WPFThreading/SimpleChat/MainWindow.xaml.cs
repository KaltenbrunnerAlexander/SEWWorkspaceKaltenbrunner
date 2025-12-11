using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleChat
{
    public partial class MainWindow : Window
    {
        private ChatServer chatServer;
        private ChatClient chatClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Start_Server(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(tbx_hostingPort.Text);
            chatServer = new ChatServer(port, this);
            chatServer.Start();
        }

        private void Button_Click_Connect(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(tbx_remoteServerPort.Text);
            chatClient = new ChatClient(port, this);
        }

        private void tbx_sendMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && chatClient != null)
            {
                chatClient.SendMessage(tbx_sendMsg.Text);

                // Textfeld löschen nach dem Senden
                tbx_sendMsg.Clear();
            }
        }
    }
}
