using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AmpelSimulation
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isRunning = true;

        public MainWindow()
        {
            InitializeComponent();
            StartTrafficLightThread();
        }

        private void StartTrafficLightThread()
        {
            Thread trafficLightThread = new Thread(() =>
            {
                while (isRunning)
                {
                    Dispatcher.Invoke(() => SetColor(Brushes.Red, Brushes.Gray, Brushes.Gray));
                    Thread.Sleep(2000);

                    Dispatcher.Invoke(() => SetColor(Brushes.Gray, Brushes.Yellow, Brushes.Gray));
                    Thread.Sleep(500);

                    Dispatcher.Invoke(() => SetColor(Brushes.Gray, Brushes.Gray, Brushes.Green));
                    Thread.Sleep(2000);

                    for (int i = 0; i < 5; i++)
                    {
                        Dispatcher.Invoke(() => SetColor(Brushes.Gray, Brushes.Gray, Brushes.Green));
                        Thread.Sleep(100);
                        Dispatcher.Invoke(() => SetColor(Brushes.Gray, Brushes.Gray, Brushes.Gray));
                        Thread.Sleep(100);
                    }
                }
            });

            trafficLightThread.IsBackground = true;
            trafficLightThread.Start();
        }

        private void SetColor(Brush red, Brush yellow, Brush green)
        {
            RedButton.Background = red;
            YellowButton.Background = yellow;
            GreenButton.Background = green;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            isRunning = false; 
        }
    }
}