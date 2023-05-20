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
    /// Interaction logic for ContractAddWindow.xaml
    /// </summary>
    public partial class ContractAddWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Contract Contract { get; set; }
        public ContractAddWindow(Contract contract)
        {
            InitializeComponent();
            Contract = contract;
            DataContext = Contract;
            db.Clients.Load();
            db.insurances.Load();
            ClientBox.ItemsSource = db.Clients.Local.ToObservableCollection();
            InsuranceBox.ItemsSource = db.insurances.Local.ToObservableCollection();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var selectedInsurance = (insurance)InsuranceBox.SelectedItem;
            var selectedClient = (Client)ClientBox.SelectedItem;
            Contract.insurance = selectedInsurance;
            Contract.Client = selectedClient;
            // Добавляем Insurance в контекст базы данных и сохраняем изменения
            db.Contracts.Add(Contract);
            db.SaveChanges();

            // Закрываем окно и возвращаем результат DialogResult = true
            DialogResult = true;
        }
    }
}
