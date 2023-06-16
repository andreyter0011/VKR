using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VKR.View;
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
            ClientAddWindow ClientAddWindow = new ClientAddWindow(new Client() { Id = Guid.NewGuid() });
            if (ClientAddWindow.ShowDialog() == true)
            {
                Client User = ClientAddWindow.Client;
                User.Id = Guid.NewGuid();
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
                HowLongContract = user.HowLongContract,
                Insurance = user.Insurance,
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
                    user.HowLongContract = UserWindow.Client.HowLongContract;
                    user.Insurance = UserWindow.Client.Insurance;
                    db.SaveChanges();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Client? user = userList.SelectedItem as Client;
            if (user is null) return;

            var insurance = db.insurances.FirstOrDefault(i => i.Client.Id == user.Id);
            if (insurance != null)
            {
                db.Entry(insurance).State = EntityState.Detached;
                insurance.Client = null;
            }

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
                detailButton.Visibility = Visibility.Visible;
                ContractAndInsuranceButton.Visibility = Visibility.Visible;
            }
            else
            {
                detailButton.Visibility = Visibility.Collapsed;
                ContractAndInsuranceButton.Visibility = Visibility.Visible;
            }
        }

        private void InsuranceCase_Click(object sender, RoutedEventArgs e)
        {
            InsuranceCaseWindow InsuranceCaseWindow = new InsuranceCaseWindow(new InsuranceCase());
            if (InsuranceCaseWindow.ShowDialog() == true)
            {
                InsuranceCase insuranceCase = InsuranceCaseWindow.InsuranceCase;
                db.SaveChanges();
                ((ClientAndInsurance)DataContext).InsuranceCases.Remove(insuranceCase);
                CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Insurances).Refresh();
            }
        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            ContractAddWindow ContractAddWindow = new ContractAddWindow(new Contract());
            if (ContractAddWindow.ShowDialog() == true)
            {
                Contract contract = ContractAddWindow.Contract;
                db.SaveChanges();
                ((ClientAndInsurance)DataContext).Contracts.Remove(contract);
                CollectionViewSource.GetDefaultView(((ClientAndInsurance)DataContext).Contracts).Refresh();
            }
        }
        private void ContractAndInsurance_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? user = userList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            AddContractAndInsurance UserWindow = new AddContractAndInsurance(new Client
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                Birth = user.Birth,
                Passport = user.Passport,
                Contract = user.Contract,
                HowLongContract = user.HowLongContract,
                Insurance = user.Insurance,
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
                    user.HowLongContract = UserWindow.Client.HowLongContract;
                    user.Insurance = UserWindow.Client.Insurance;
                    db.SaveChanges();

                    ContractAndInsuranceButton.IsEnabled = false;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PassportSearchWindow passportSearchWindow = new PassportSearchWindow();
            passportSearchWindow.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
        }
    }
}
