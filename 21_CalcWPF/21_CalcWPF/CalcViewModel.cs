using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _21_CalcWPF
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel model = new CalculatorModel();

        // Commands
        public ICommand AddCommand { get; }
        public ICommand SubCommand { get; }
        public ICommand MulCommand { get; }
        public ICommand DivCommand { get; }
        public ICommand ResetCommand { get; }

        // Private Felder
        private double number1;
        private double number2;
        private double result;
        private string status;
        private SolidColorBrush resultColor = Brushes.Black;

        public CalculatorViewModel()
        {
            // Initialisierung der Commands
            AddCommand = new SimpleCommand(Add);
            SubCommand = new SimpleCommand(Sub);
            MulCommand = new SimpleCommand(Mul);
            DivCommand = new SimpleCommand(Div);
            ResetCommand = new SimpleCommand(Reset);

            Status = "Bereit"; // Initialer Status
        }

        // Properties für Bindings
        public double Number1
        {
            get => number1;
            set { number1 = value; OnPropertyChanged(nameof(Number1)); }
        }

        public double Number2
        {
            get => number2;
            set { number2 = value; OnPropertyChanged(nameof(Number2)); }
        }

        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
                UpdateColor(); // Farbe aktualisieren, wenn sich das Ergebnis ändert [cite: 71]
            }
        }

        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }

        public SolidColorBrush ResultColor
        {
            get => resultColor;
            set { resultColor = value; OnPropertyChanged(nameof(ResultColor)); }
        }

        // Logik-Methoden
        private void Add(object obj)
        {
            Result = model.Add(Number1, Number2);
            Status = "Berechnung Addition ok - Hurra"; 
        }

        private void Sub(object obj)
        {
            Result = model.Sub(Number1, Number2);
            Status = "Berechnung Subtraktion ok"; 
        }

        private void Mul(object obj)
        {
            Result = model.Mul(Number1, Number2);
            Status = "Berechnung Multiplikation ok";
        }

        private void Div(object obj)
        {
            if (Number2 == 0)
            {
                Result = 0;
                Status = "Fehler bei der Division: Es wurde versucht, durch 0 (null) zu teilen."; 
            }
            else
            {
                Result = model.Div(Number1, Number2);
                Status = "Berechnung Division ok";
            }
        }

        private void Reset(object obj)
        {
            Number1 = 0;
            Number2 = 0;
            Result = 0;
            Status = "Reset durchgeführt";
        }

        // Hilfsmethode für den Farbwechsel [cite: 71, 73]
        private void UpdateColor()
        {
            if (Result >= 0)
                ResultColor = Brushes.Green;
            else
                ResultColor = Brushes.Red;
        }

        // INotifyPropertyChanged Implementierung
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // Hilfsklasse für Commands [cite: 69]
    public class SimpleCommand : ICommand
    {
        private readonly Action<object> _execute;
        public SimpleCommand(Action<object> execute) => _execute = execute;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged;
    }
}
