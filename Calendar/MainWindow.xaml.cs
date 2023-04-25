using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<DayList> MainDayList = new List<DayList>();

        public MainWindow()
        {
            InitializeComponent();
            var cp = new CalendarPage();
            MainDayList = Jsoner<DayList>.Deserialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\ДниИдут.json");
            Framer.Content = cp;
        }

        private DateTime erDateTime = DateTime.Now;
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                (sender as MainWindow).DragMove();

        }
    }

    public class Jsoner<T>
    {
        static public void Serialize(List<T> list, string fileName, string SubWay = "")
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + SubWay + $"/{fileName}.json", JsonConvert.SerializeObject(list));
        }
        static public List<T> Deserialize(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            }
            catch
            {
                MessageBox.Show("Ошибочка в пути или файле");
                return null;
            }
        }
    }
}
