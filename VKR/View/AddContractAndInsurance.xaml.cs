using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using VKR.Model;

namespace VKR.View
{
    /// <summary>
    /// Interaction logic for AddContractAndInsurance.xaml
    /// </summary>
    public partial class AddContractAndInsurance : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Client Client { get; set; }
        public AddContractAndInsurance(Client client)
        {
            InitializeComponent();
            Client = client;
            DataContext = Client;
            db.Contracts.Load();
            ContractBox.ItemsSource = db.Contracts.Local.ToObservableCollection();
            db.insurances.Load();
            InsuranceBox.ItemsSource = db.insurances.Local.ToObservableCollection();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var selectedContract = (Contract)ContractBox.SelectedItem;
            var selectedInsurance = (insurance)InsuranceBox.SelectedItem;
            if (selectedContract != null && selectedInsurance != null)
            {
                Client.Contract = selectedContract;
                Client.Insurance = selectedInsurance;
                db.SaveChanges();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a client.");
            }
        }
    }
}
