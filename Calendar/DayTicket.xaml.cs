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
    /// Логика взаимодействия для DayTicket.xaml
    /// </summary>
    public partial class DayTicket : UserControl
    {
        public DayTicket()
        {
            InitializeComponent();
        }
        public DayTicket(int i, BitmapImage bitmapImage)
        {
            InitializeComponent();
            DayNumber.Content = null;
            DayNumber.Content = i;
            TopTicket.Source = bitmapImage;
            _contentLoaded = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MyBorder.Child = null;
            (Application.Current.MainWindow as MainWindow).Framer.Content= new Ticket();
        }
    }
}
