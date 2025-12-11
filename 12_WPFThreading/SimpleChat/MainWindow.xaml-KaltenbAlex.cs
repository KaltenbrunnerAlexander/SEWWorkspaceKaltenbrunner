using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleChat
{
    /// <summary>
    /// /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Start_Server(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(tbx_hostingPort.Text);
            ChatServer server = new ChatServer(port, this);
            chatServer.Start();
        }
        private void Button_Click_Connect(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(tbx_remoteServerPort.Text);
            chatClient = new ChatClient(port, this);
        }

        private void lst_receiveMessage(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                chatClient.SendMessage(tbx_sendMsg.Text);

            }
        }


    }
}