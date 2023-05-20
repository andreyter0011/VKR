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
    /// Interaction logic for InsuranceCaseWindow.xaml
    /// </summary>
    public partial class InsuranceCaseWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public InsuranceCase InsuranceCase { get; set; }
        public InsuranceCaseWindow(InsuranceCase insuranceCase)
        {
            InitializeComponent();

            InsuranceCase = insuranceCase;
            DataContext = InsuranceCase;
            db.insurances.Load();
            InsuranceBox.ItemsSource = db.insurances.Local.ToObservableCollection();
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранного клиента
            var selectedClient = (insurance)InsuranceBox.SelectedItem;

            // Проверяем, что клиент существует
            if (selectedClient != null)
            {
                // Устанавливаем ClientId в объекте Insurance
                InsuranceCase.insurance = selectedClient;

                // Добавляем Insurance в контекст базы данных и сохраняем изменения
                db.insuranceCases.Add(InsuranceCase);
                db.SaveChanges();

                // Закрываем окно и возвращаем результат DialogResult = true
                DialogResult = true;
            }
            else
            {
                // Выводим сообщение об ошибке, если клиент не выбран
                MessageBox.Show("Please select a client.");
            }
        }
    }
}
