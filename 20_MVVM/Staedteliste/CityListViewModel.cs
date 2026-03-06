using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Staedteliste
{
    internal class CityListViewModel : INotifyPropertyChanged
    {
        private List<CityListModel> cities;
        private int currentIndex = 0;

        private CityListModel currentCity;

        public CityListModel CurrentCity
        {
            get { return currentCity; }
            set
            {
                currentCity = value;
                OnPropertyChanged(nameof(CurrentCity));
            }
        }

        public ICommand NextCityCommand { get; }

        public CityListViewModel()
        {
            cities = new List<CityListModel>()
            {
                new CityListModel{ SearchCity="Wien", Country="Österreich", Population=1982097, CapitalCity=true},
                new CityListModel{ SearchCity="München", Country="Deutschland", Population=1612429, CapitalCity=false},
                new CityListModel{ SearchCity="Paris", Country="Frankreich", Population=2148000, CapitalCity=true},
                new CityListModel{ SearchCity="Madrid", Country="Spanien", Population=3223000, CapitalCity=true},
                new CityListModel{ SearchCity="Mailand", Country="Italien", Population=1370000, CapitalCity=false},
                new CityListModel{ SearchCity="Manchester", Country="Vereinigtes Königreich", Population=570000, CapitalCity=false},
                new CityListModel{ SearchCity="Prag", Country="Tschechien", Population=1309000, CapitalCity=true},
                new CityListModel{ SearchCity="Budapest", Country="Ungarn", Population=1756000, CapitalCity=true},
                new CityListModel{ SearchCity="Brüssel", Country="Belgien", Population=1204000, CapitalCity=true},
                new CityListModel{ SearchCity="Amsterdam", Country="Niederlande", Population=872000, CapitalCity=true},
                new CityListModel{ SearchCity="Zürich", Country="Schweiz", Population=421000, CapitalCity=false}
            };

            CurrentCity = cities[currentIndex];

            NextCityCommand = new RelayCommand(NextCity);
        }

        private void NextCity()
        {
            currentIndex++;

            if (currentIndex >= cities.Count)
                currentIndex = 0;

            CurrentCity = cities[currentIndex];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
