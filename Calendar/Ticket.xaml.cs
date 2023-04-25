using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private DayList dayList;
        private DateTime FDt;
        public Ticket(string DayOfMounth)
        {
            InitializeComponent();
            DateTime dateTime = Convert.ToDateTime(CalendarPage.textData);
            FDt = new DateTime(dateTime.Year, dateTime.Month, int.Parse(DayOfMounth));
            TicketData.Text = FDt.ToLongDateString();
            string dson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Deals.json");
            dayList = new DayList(FDt, JsonConvert.DeserializeObject<List<DItem>>(dson));
            ListViewDeals.Items.Clear();
            foreach (DayList itDayList in MainWindow.MainDayList)
            {
                if (itDayList.DayData == FDt)
                {
                    foreach (var item in itDayList.Items)
                    {
                        DayItem dayItem = new DayItem(item);
                        dayItem.Height = 70;
                        dayItem.ThatCheckBox.IsChecked = item.IsChecked;
                        dayItem.mTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
                        ListViewDeals.Items.Add(dayItem);
                    }
                    break;
                }
                if (itDayList.DayData != FDt)
                {
                    foreach (var item in dayList.Items)
                    {
                        DayItem dayItem = new DayItem(item);
                        dayItem.Height = 70;
                        dayItem.mTextBlock.Content = item.Name;
                        dayItem.ThatCheckBox.IsChecked = false;
                        dayItem.mTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
                        ListViewDeals.Items.Add(dayItem);
                    }
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MW = (Application.Current.MainWindow as MainWindow).Framer.Content = new CalendarPage();
            CalendarPage page = MW as CalendarPage;
            page.WrapPanelDays.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(page.DatePick.DisplayDate.Year, page.DatePick.DisplayDate.Month); i++)
            {
                DayTicket dt = new DayTicket(i + 1, new BitmapImage(new Uri(@"D:\WORK\С# WPF\Calendar\Pics\dog.png")));
                if (i + 1 == DateTime.Now.Day && page.DatePick.DisplayDate.Month == DateTime.Now.Month)
                {
                    Brush b = new SolidColorBrush(Color.FromRgb(240, 240, 230));
                    dt.Background = b;
                    dt.Background.Opacity = 0.2;
                }
                page.WrapPanelDays.Children.Add(dt);
            }
            page.MyBorder.Child = page.WrapPanelDays;

        }

        private void Saver_Click(object sender, RoutedEventArgs e)
        {
            List<DayList> tester = Jsoner<DayList>.Deserialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ДниИдут.json");

            dayList.Items.Clear();
            foreach (DayItem itmItem in ListViewDeals.Items)
            {
                dayList.Items.Add(new DItem(
                    itmItem.mTextBlock.Content.ToString(),
                    itmItem.Ico.Source.ToString(),
                    itmItem.ThatCheckBox.IsChecked.Value)
                );
            }

            var WithMyData = tester.Where(x => x.DayData == FDt).ToList();
            foreach (DayList date in tester)
            {
                if (WithMyData.Count != 0) // если этот день уже записывался и есть в файле, то изменить его
                {
                    date.Items.Clear();
                    date.Items = dayList.Items;
                    break;
                }

                if (WithMyData.Count == 0)
                { // если этот день НЕ записывался, то добавить
                    MessageBox.Show("!");
                    MainWindow.MainDayList.Add(dayList);
                    break;
                }
            }
            Jsoner<DayList>.Serialize(MainWindow.MainDayList, "ДниИдут");
        }
    }
}
