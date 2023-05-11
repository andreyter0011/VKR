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
    }
}
