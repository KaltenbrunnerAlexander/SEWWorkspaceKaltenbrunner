using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _23_KlickCounter
{
    internal class KlickCounterViewModel
    {
        public ObservableCollection<LogEntry> Logs { get; } = new ObservableCollection<LogEntry>();

        public ICommand LogCommand { get; }
        public ICommand ClearCommand { get; }

        public KlickCounterViewModel()
        {
            LogCommand = new RelayCommand(AddEntry);
            ClearCommand = new RelayCommand(ClearLogs, () => Logs.Count > 0);
        }

        private void AddEntry()
        {
            Logs.Add(new LogEntry
            {
                Id = Logs.Count + 1,
                Timestamp = DateTime.Now
            });

            OnPropertyChanged(nameof(TotalClicks));
        }

        private void ClearLogs()
        {
            Logs.Clear();

            OnPropertyChanged(nameof(TotalClicks));
        }

        public string TotalClicks => $"Gesamtanzahl Klicks: {Logs.Count}";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
