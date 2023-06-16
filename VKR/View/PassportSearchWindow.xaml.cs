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

namespace VKR.View
{
    /// <summary>
    /// Interaction logic for PassportSearchWindow.xaml
    /// </summary>
    public partial class PassportSearchWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public PassportSearchWindow()
        {
            InitializeComponent();
        }
        private void passportTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
