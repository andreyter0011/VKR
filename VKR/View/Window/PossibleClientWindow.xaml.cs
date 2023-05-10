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
    /// Interaction logic for PossibleClientWindow.xaml
    /// </summary>
    public partial class PossibleClientWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public PossibleClientWindow()
        {
            InitializeComponent();
            Loaded += PossibleClientWindow_loaded;
        }
        private void PossibleClientWindow_loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.PossibleClients.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.PossibleClients.Local.ToObservableCollection();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PossibleClientAddWindow PossibleClientAddWindow = new PossibleClientAddWindow(new PossibleClient());
            if (PossibleClientAddWindow.ShowDialog() == true)
            {
                PossibleClient User = PossibleClientAddWindow.PossibleClient;
                db.PossibleClients.Add(User);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            PossibleClient? user = userList.SelectedItem as PossibleClient;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            PossibleClientAddWindow UserWindow = new PossibleClientAddWindow(new PossibleClient
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                Birth = user.Birth,
                Passport = user.Passport
            });

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.PossibleClients.Find(UserWindow.PossibleClient.Id);
                if (user != null)
                {
                    user.Age = UserWindow.PossibleClient.Age;
                    user.Name = UserWindow.PossibleClient.Name;
                    user.Birth = UserWindow.PossibleClient.Birth;
                    user.Passport = UserWindow.PossibleClient.Passport;
                    db.SaveChanges();
                    userList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            PossibleClient? user = userList.SelectedItem as PossibleClient;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.PossibleClients.Remove(user);
            db.SaveChanges();
        }
    }
}
