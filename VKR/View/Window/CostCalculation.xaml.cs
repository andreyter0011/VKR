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
        public insurance Insurance { get; set; }
        public CostCalculation(insurance insurance)
        {
            InitializeComponent();

            Insurance = insurance;
            DataContext = Insurance;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
