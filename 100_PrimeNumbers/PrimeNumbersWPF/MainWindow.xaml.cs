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

namespace PrimeNumbersWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread primeThread;
        private bool shouldRun = false;
        public MainWindow()
        {

            InitializeComponent();
        }

        private bool isPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void SearchForPrimeNumbers()
        {
            lbl_PrimeNumber.Content = "2";
            int zahl = 2;
            while (true)
            {
                if (isPrime(zahl))
                {
                    lbl_PrimeNumber.Dispatcher.Invoke(() =>
                    {
                        lbl_PrimeNumber.Content = $"Largest PrimeNumber: {zahl}";
                    });
                }
                zahl = zahl + 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (primeThread == null || !primeThread.IsAlive)
            {
                shouldRun = true;
                primeThread = new Thread(new ThreadStart(SearchForPrimeNumbers));
                primeThread.Start();
            }
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            shouldRun = false;
        }
    }
}
