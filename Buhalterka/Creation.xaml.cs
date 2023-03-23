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
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Buhalterka
{
    /// <summary>
    /// Логика взаимодействия для Creation.xaml
    /// </summary>
    public partial class Creation : Window
    {
        public Creation()
        {
            InitializeComponent();
            Boss.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Boss.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
            Type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
            Class.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Class.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
            List<Type> json1 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            Buhalterka.Type.Types = json1;
        }
        private void Boss_Click(object sender, RoutedEventArgs e)
        {
            Title = "Создание босса";
            Framer1.Visibility = Visibility.Visible;
            Framer2.Visibility = Visibility.Hidden;
            Framer3.Visibility = Visibility.Hidden;

            Boss.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Boss.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
            Type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
            Class.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB41004"));
            Class.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C231B"));
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            Title = "Создание класса";
            Framer1.Visibility = Visibility.Hidden;
            Framer2.Visibility = Visibility.Visible;
            Framer3.Visibility = Visibility.Hidden;

            Boss.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF39B404"));
            Boss.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF358C1B"));
            Type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF39B404"));
            Type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF358C1B"));
            Class.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF39B404"));
            Class.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF358C1B"));
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            Title = "Создание типа";
            Framer1.Visibility = Visibility.Hidden;
            Framer2.Visibility = Visibility.Hidden;
            Framer3.Visibility = Visibility.Visible;
            Boss.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0455B4"));
            Boss.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1B268C"));
            Type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0455B4"));
            Type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1B268C"));
            Class.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0455B4"));
            Class.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1B268C"));
        }
    }
}
