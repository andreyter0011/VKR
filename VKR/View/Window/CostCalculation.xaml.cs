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
    /// Interaction logic for CostCalculation.xaml
    /// </summary>
    public partial class CostCalculation : Window
    {
        ApplicationContext db = new ApplicationContext();
        public insurance Insurance { get; set; }
        public CostCalculation(insurance insurance)
        {
            InitializeComponent();

            Insurance = insurance;
            DataContext = Insurance;
            db.Clients.Load();
            ClientBox.ItemsSource = db.Clients.Local.ToObservableCollection();
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранного клиента
            var selectedClient = (Client)ClientBox.SelectedItem;

            // Проверяем, что клиент существует
            if (selectedClient != null)
            {
                // Устанавливаем ClientId в объекте Insurance
                Insurance.Client = selectedClient;

                // Добавляем Insurance в контекст базы данных и сохраняем изменения
                db.insurances.Add(Insurance);
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

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            double propertyValue = double.Parse(PropertyValue.Text);
            double insuranceCoverage = double.Parse(InsuranceCoverage.Text) * 0.01;
            double degreeRisk = double.Parse(DegreeRisk.Text);

            // Выполняем расчет стоимости страхования
            double insuranceCost = propertyValue * insuranceCoverage * degreeRisk;

            // Устанавливаем результат в TextBox для стоимости страхования
            PriceInsurance.Text = insuranceCost.ToString();
            Insurance.PriceInsurance = Convert.ToString(insuranceCost);
        }
    }
}
