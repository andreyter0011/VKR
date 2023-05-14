using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using VKR.Model;

namespace VKR.ViewModel
{
    public class ClientAndInsurance : INotifyPropertyChanged
    {
        private readonly ApplicationContext db = new ApplicationContext();
        private ObservableCollection<Client> clients;
        private ObservableCollection<insurance> insurances;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
            }
        }

        public ObservableCollection<insurance> Insurances
        {
            get => insurances;
            set
            {
                insurances = value;
            }
        }

        public ClientAndInsurance()
        {
            db.Database.EnsureCreated();
            db.Clients.Load();
            Clients = db.Clients.Local.ToObservableCollection();
            db.insurances.Load();
            Insurances = db.insurances.Local.ToObservableCollection();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
