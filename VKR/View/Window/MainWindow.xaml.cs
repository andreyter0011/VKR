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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VKR.Model;
using VKR.ViewModel;

namespace VKR
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ClientAndInsurance();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClientAddWindow ClientAddWindow = new ClientAddWindow(new Client());
            if (ClientAddWindow.ShowDialog() == true)
            {
                Client User = ClientAddWindow.Client;
                db.Clients.Add(User);
                db.SaveChanges();
                ((ClientAndInsurance)DataContext).Clients.Add(User);
                CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Clients).Refresh();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? user = userList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            ClientAddWindow UserWindow = new ClientAddWindow(new Client
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                Birth = user.Birth,
                Passport = user.Passport,
                Contract = user.Contract,
                DataStartContract = user.DataStartContract,
                DataEndContract = user.DataEndContract,
                TypeContract = user.TypeContract,
                PriceContract = user.PriceContract,
                HowLongContract = user.HowLongContract,
            });

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Clients.Find(UserWindow.Client.Id);
                if (user != null)
                {
                    user.Age = UserWindow.Client.Age;
                    user.Name = UserWindow.Client.Name;
                    user.Birth = UserWindow.Client.Birth;
                    user.Passport = UserWindow.Client.Passport;
                    user.Contract = UserWindow.Client.Contract;
                    user.DataStartContract = UserWindow.Client.DataStartContract;
                    user.DataEndContract = UserWindow.Client.DataEndContract;
                    user.TypeContract = UserWindow.Client.TypeContract;
                    user.PriceContract = UserWindow.Client.PriceContract;
                    user.HowLongContract = UserWindow.Client.HowLongContract;
                    db.SaveChanges();
                    CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Clients).Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? user = userList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.Clients.Remove(user);
            db.SaveChanges();
            ((ClientAndInsurance)DataContext).Clients.Remove(user);
            CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Clients).Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client? user = userList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            Detail detail = new Detail();
            detail.Show();
        }
        private void Insurance_Click(object sender, RoutedEventArgs e)
        {
            CostCalculation CostCalculation = new CostCalculation(new insurance());
            if (CostCalculation.ShowDialog() == true)
            {
                insurance User = CostCalculation.Insurance;
                db.SaveChanges();
                ((ClientAndInsurance)DataContext).Insurances.Remove(User);
                CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Insurances).Refresh();
            }
        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userList.SelectedItem != null)
            {
                CalculateButton.Visibility = Visibility.Visible;
                detailButton.Visibility = Visibility.Visible;
            }
            else
            {
                CalculateButton.Visibility = Visibility.Collapsed;
                detailButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
