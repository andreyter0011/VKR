using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

namespace VKR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Clients.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Clients.Local.ToObservableCollection();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClientAddWindow ClientAddWindow = new ClientAddWindow(new Client());
            if (ClientAddWindow.ShowDialog() == true)
            {
                Client User = ClientAddWindow.Client;
                db.Clients.Add(User);
                db.SaveChanges();
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
                    userList.Items.Refresh();
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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Client? user = userList.SelectedItem as Client;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            Detail detail = new Detail();

            frame.NavigationService.Navigate(detail);

            ButtonPanel.Visibility = Visibility.Collapsed;
            DetailButton.Visibility = Visibility.Collapsed;
            userList.Visibility = Visibility.Collapsed;
        }
        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            // Проверяем, что текущая страница - Detail
            if (e.Content is Detail)
            {
                // Скрываем нужные элементы на MainWindow
                ButtonPanel.Visibility = Visibility.Collapsed;
                DetailButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Показываем элементы на MainWindow
                ButtonPanel.Visibility = Visibility.Visible;
                DetailButton.Visibility = Visibility.Visible;
            }
        }
    }
}
