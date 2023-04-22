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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для ModernUIWindowsPanel.xaml
    /// </summary>
    public partial class ModernUIWindowsPanel : UserControl
    {
        public ModernUIWindowsPanel()
        {
            InitializeComponent();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Minimized;
        }

        private bool Maximized = false;
        private void Maximize(object sender, RoutedEventArgs e)
        {
            Maximized = !Maximized;
            if (Maximized)
            {
                try
                {
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Maximized;
                }
                catch { }
            }
            else
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Normal;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Close();
            Environment.Exit(0);
        }
    }
}
