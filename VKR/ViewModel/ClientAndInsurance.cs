using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VKR.Model;

namespace VKR.ViewModel
{
    public class ClientAndInsurance
    {
        private readonly ApplicationContext db = new ApplicationContext();
        private ObservableCollection<Client> clients;
        private ObservableCollection<insurance> insurances;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<insurance> Insurances
        {
            get => insurances;
            set
            {
                insurances = value;
                OnPropertyChanged();
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
