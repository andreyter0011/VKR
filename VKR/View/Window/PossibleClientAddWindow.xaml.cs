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
    /// Interaction logic for PossibleClientAddWindow.xaml
    /// </summary>
    public partial class PossibleClientAddWindow : Window
    {
        public PossibleClient PossibleClient { get; set; }
        public PossibleClientAddWindow(PossibleClient possibleClient)
        {
            InitializeComponent();
            PossibleClient = possibleClient;
            DataContext = PossibleClient;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
