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

namespace VKR
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class ClientAddWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Client Client { get; set; }
        public ClientAddWindow(Client client)
        {
            InitializeComponent();
            Client = client;
            DataContext = Client;
            db.insurances.Load();
            InsuranceBox.ItemsSource = db.insurances.Local.ToObservableCollection();
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            var selectedInsurance = (insurance)InsuranceBox.SelectedItem;
            Client.Insurance = selectedInsurance;
            // Добавляем Insurance в контекст базы данных и сохраняем изменения
            db.SaveChanges();

            // Закрываем окно и возвращаем результат DialogResult = true
            DialogResult = true;
        }
    }
}
