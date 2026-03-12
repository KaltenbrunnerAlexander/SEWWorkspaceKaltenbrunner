using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace MVVM_Example
{
    internal class PersonViewModel : ICommand, INotifyPropertyChanged
    {
        DispatcherTimer timer;
        public ICommand ClickCommand { 
            get { return this; } 
        }
        public string PersonName
        {
            get
            {
                return person.Name;
            }
            set
            {
                person.Name = value;
            }
        }

        public string PersonEMail
        {
            get
            {
                return person.Email;
            }
            set
            {
                person.Email = value;
            }
        }

        private PersonModel person;
        public PersonViewModel()
        {
            person = new PersonModel
            {
                Name = "John Doe",
                Email = "john@mail.com"
            };
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            PersonName = "John Doe " + DateTime.Now.Second;
            PersonEMail = "john.mail@htlwy.at";
        }
    }
}
