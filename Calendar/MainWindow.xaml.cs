using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CardT.Content = Title;
            DatePick.DisplayDate = DateTime.Now;
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DateTime.Now.Year;
            List<DayTicket> dayTickets = new List<DayTicket>();
            for (int i = 0; i < DateTime.DaysInMonth(erDateTime.Year, erDateTime.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\\WORK\\С# WPF\\Calendar\\calendar-icon_34471.ico")));
                if (i + 1 == DateTime.Now.Day && DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                dayTickets.Add(dt);
                WrapPanelDays.Children.Add(dayTickets[i]);
            }
        }

        private DateTime erDateTime = DateTime.Now;
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                (sender as MainWindow).DragMove();

        }

        private void DatePick_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DatePick.DisplayDate.Year;
            List<DayTicket> dayTickets = new List<DayTicket>();
            WrapPanelDays.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(DatePick.DisplayDate.Year, DatePick.DisplayDate.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\\WORK\\С# WPF\\Calendar\\calendar-icon_34471.ico")));
                if (i + 1 == DateTime.Now.Day && DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                dayTickets.Add(dt);
                WrapPanelDays.Children.Add(dayTickets[i]);
            }
        }

        private void ToPrev_Click(object sender, RoutedEventArgs e)
        {
            DatePick.Text = DatePick.DisplayDate.AddMonths(-1).ToString();
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DatePick.DisplayDate.Year;
            List<DayTicket> dayTickets = new List<DayTicket>();
            WrapPanelDays.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(DatePick.DisplayDate.Year, DatePick.DisplayDate.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\\WORK\\С# WPF\\Calendar\\calendar-icon_34471.ico")));
                if (i + 1 == DateTime.Now.Day && DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                dayTickets.Add(dt);
                WrapPanelDays.Children.Add(dayTickets[i]);
            }
        }

        private void ToNext_Click(object sender, RoutedEventArgs e)
        {
            DatePick.Text = DatePick.DisplayDate.AddMonths(1).ToString();
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DatePick.DisplayDate.Year;
            List<DayTicket> dayTickets = new List<DayTicket>();
            WrapPanelDays.Children.Clear();
            //MessageBox.Show(DatePick.Text);
            for (int i = 0; i < DateTime.DaysInMonth(DatePick.DisplayDate.Year, DatePick.DisplayDate.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\\WORK\\С# WPF\\Calendar\\calendar-icon_34471.ico")));
                if (i + 1 == DateTime.Now.Day && DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                dayTickets.Add(dt);
                WrapPanelDays.Children.Add(dayTickets[i]);
            }
        }
    }
}
