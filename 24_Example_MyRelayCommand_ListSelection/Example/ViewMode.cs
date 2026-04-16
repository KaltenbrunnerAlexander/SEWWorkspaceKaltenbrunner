using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Example
{

    internal class ViewModel : INotifyPropertyChanged
    {
        public string DisplayText { get; set; } = "Hello";
        public Person SelectedPerson { get; set; }

        public ICommand CommandOK { get; set; }
        public ICommand CommandCancel { get; set; }

        public ICommand ListCommand {  get; set; }

        public List<Person> People { get; set; }

        public ViewModel() 
        {
            CommandOK = new MyRelayCommand(DoOk);
            CommandCancel = new MyRelayCommand(DoCancel);
            ListCommand = new MyRelayCommand(DoListSelected);
            People = new List<Person>();
            People.Add(new Person() { Name="Max Mustermann", EMail="muster@mail.com" });
            People.Add(new Person() { Name = "Donald Duck", EMail = "dd@mail.com" });
            People.Add(new Person() { Name = "Daisy Duck", EMail = "daisy@mail.com" });
        }

        public void DoListSelected()
        {
            DisplayText = SelectedPerson.ToString();
            Invoke();
        }

        public void DoOk()
        {
            DisplayText = "OK";
            Invoke();
        }

        public void DoCancel()
        {
            DisplayText = "Cancel";
            Invoke();
        }

        public void Invoke()
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DisplayText"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
