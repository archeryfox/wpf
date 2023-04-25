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
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            DatePick.DisplayDate = DateTime.Now;
            DatePick.Text = DateTime.Now.ToString();
            Update();
        }
        
        public static string textData;


        private void Update()
        {
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DatePick.DisplayDate.Year;
            WrapPanelDays.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(DatePick.DisplayDate.Year, DatePick.DisplayDate.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\WORK\С# WPF\Calendar\Pics\dog.png")));
                if (i + 1 == DateTime.Now.Day && DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                WrapPanelDays.Children.Add(dt);
            }
        }
        private void DatePick_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateNow.Content = CultureInfo.GetCultureInfoByIetfLanguageTag("ru-RU").DateTimeFormat.GetMonthName(DatePick.DisplayDate.Month) + " " + DatePick.DisplayDate.Year;
            Update();
            textData = DatePick.DisplayDate.ToString();
        }

        private void ToPrev_Click(object sender, RoutedEventArgs e)
        {
            DatePick.Text = DatePick.DisplayDate.AddMonths(-1).ToString();
            Update();
        }

        private void ToNext_Click(object sender, RoutedEventArgs e)
        {
            DatePick.Text = DatePick.DisplayDate.AddMonths(1).ToString();
            Update();
        }
    }
}
