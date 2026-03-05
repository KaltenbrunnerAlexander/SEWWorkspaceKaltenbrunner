using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using System.IO;

namespace TimerExample
{
    internal class TimedNumberViewModel : INotifyPropertyChanged, ICommand
    {
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();

        private TimedNumberModel model = new TimedNumberModel();

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ICommand CmdButtonClick { get; set; }
        public int Number {
            get { return model.Number; }
            set {
                model.Number = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Number"));
            }
        }

        public void UpdateNumber(object sender, EventArgs args)
        {
            Number = random.Next(0, 1000);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if ((string)parameter == "value0")
                Number = 0;
            else if ((string)parameter=="value1000")
                Number = 1000;
        }


        public TimedNumberViewModel()
        {
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += UpdateNumber;
            timer.Start();

            CmdButtonClick = this;
        }


    }
}
