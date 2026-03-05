using System;
using System.Collections.Generic;
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

namespace TextObservers
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
   
        private void InputTextBox_TextChanged(object sender,TextChangedEventArgs e)
        {
            string text = InputTextBox.Text;

            Label1.Content = text;
            Label2.Content = text;
            Label3.Content = text;
            Label4.Content = text;
            Label5.Content = text;
        }
    }
}
