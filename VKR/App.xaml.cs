using ActiproSoftware.Windows.Themes;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VKR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Configure Actipro themes for native controls and set an Office theme that is similar to Word
            ThemeManager.BeginUpdate();
            try
            {
                ThemeManager.AreNativeThemesEnabled = true;
                ThemeManager.CurrentTheme = ThemeNames.OfficeColorfulIndigo;
            }
            finally
            {
                ThemeManager.EndUpdate();
            }

            // Call the base method
            base.OnStartup(e);
        }
    }
}
