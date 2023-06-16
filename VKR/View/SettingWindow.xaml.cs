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

namespace VKR.View
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            // Получите текущую тему приложения
            var currentTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault();

            // Удалите текущую тему
            Application.Current.Resources.MergedDictionaries.Remove(currentTheme);

            // Определите путь к новой теме в зависимости от текущей
            var newThemeUri = (currentTheme.Source.ToString() == "LightTheme.xaml") ? "DarkTheme.xaml" : "LightTheme.xaml";

            // Создайте новую тему и добавьте ее в ресурсы приложения
            var newTheme = new ResourceDictionary() { Source = new Uri(newThemeUri, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
