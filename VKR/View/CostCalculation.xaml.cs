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
            db.Contracts.Load();
            ContractBox.ItemsSource = db.Contracts.Local.ToObservableCollection();
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            var selectedContract = (Contract)ContractBox.SelectedItem;

            if (selectedContract != null)
            {
                Insurance.Contract = selectedContract;

                db.insurances.Add(Insurance);
                db.SaveChanges();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a client.");
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double propertyValue = double.Parse(PropertyValue.Text);
            double insuranceCoverage = double.Parse(InsuranceCoverage.Text) * 0.01;
            double degreeRisk = double.Parse(DegreeRisk.Text);
            double insuranceCost = 0;

            if (ContractBox.SelectedItem is Contract selectedContract)
            {
                string selectedValue = selectedContract.Name;
                int SelectedBudget = selectedContract.insuranceCompanyBudget;
                if (selectedValue == "Недвижимость")
                {
                    double squareMeters = double.Parse(SquareMetersTextBox.Text);
                    double roomCount = double.Parse(RoomCountTextBox.Text);
                    double floor = double.Parse(FloorTextBox.Text);

                    // Выполняем расчет стоимости страхования для недвижимости
                    insuranceCost = propertyValue * insuranceCoverage * degreeRisk * (squareMeters + roomCount + floor);
                }
                else if (selectedValue == "Движимое имущество")
                {
                    double vehicleType = double.Parse(VehicleTypeTextBox.Text);
                    double usagePeriod = double.Parse(UsagePeriodTextBox.Text);
                    double horsepower = double.Parse(HorsepowerTextBox.Text);
                    double kilowatts = double.Parse(KilowattsTextBox.Text);

                    // Выполняем расчет стоимости страхования для движимого имущества
                    insuranceCost = propertyValue * insuranceCoverage * degreeRisk * (vehicleType + usagePeriod + horsepower + kilowatts);
                }
                if (insuranceCost > SelectedBudget)
                {
                    // Вывод сообщения о нехватке бюджета
                    MessageBox.Show("Нехватка бюджета");
                }
            }
            // Устанавливаем результат в TextBox для стоимости страхования
            PriceInsurance.Text = insuranceCost.ToString();
            Insurance.PriceInsurance = Convert.ToString(insuranceCost);
        }
        private void ContractBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContractBox.SelectedItem is Contract selectedContract)
            {
                // Получение выбранного значения ComboBox
                string selectedValue = selectedContract.Name;

                // Проверка выбранного значения и установка видимости соответствующих элементов интерфейса
                if (selectedValue == "Недвижимость")
                {
                    SquareMeters.Visibility = Visibility.Visible;
                    SquareMetersTextBox.Visibility = Visibility.Visible;
                    RoomCount.Visibility = Visibility.Visible;
                    RoomCountTextBox.Visibility = Visibility.Visible;
                    Floor.Visibility = Visibility.Visible;
                    FloorTextBox.Visibility = Visibility.Visible;

                    VehicleType.Visibility = Visibility.Collapsed;
                    VehicleTypeTextBox.Visibility = Visibility.Collapsed;
                    UsagePeriod.Visibility = Visibility.Collapsed;
                    UsagePeriodTextBox.Visibility = Visibility.Collapsed;
                    Horsepower.Visibility = Visibility.Collapsed;
                    HorsepowerTextBox.Visibility = Visibility.Collapsed;
                    Kilowatts.Visibility = Visibility.Collapsed;
                    KilowattsTextBox.Visibility = Visibility.Collapsed;
                }
                else if (selectedValue == "Движимое имущество")
                {
                    SquareMeters.Visibility = Visibility.Collapsed;
                    SquareMetersTextBox.Visibility = Visibility.Collapsed;
                    RoomCount.Visibility = Visibility.Collapsed;
                    RoomCountTextBox.Visibility = Visibility.Collapsed;
                    Floor.Visibility = Visibility.Collapsed;
                    FloorTextBox.Visibility = Visibility.Collapsed;

                    VehicleType.Visibility = Visibility.Visible;
                    VehicleTypeTextBox.Visibility = Visibility.Visible;
                    UsagePeriod.Visibility = Visibility.Visible;
                    UsagePeriodTextBox.Visibility = Visibility.Visible;
                    Horsepower.Visibility = Visibility.Visible;
                    HorsepowerTextBox.Visibility = Visibility.Visible;
                    Kilowatts.Visibility = Visibility.Visible;
                    KilowattsTextBox.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
