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
    /// Логика взаимодействия для DayItem.xaml
    /// </summary>
    public partial class DayItem : UserControl
    {
        public DayItem()
        {
        }

        public DayItem(DItem dtDItem)
        {
            InitializeComponent();
            mTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            ThatCheckBox.IsChecked = dtDItem.IsChecked;
            Ico.Source = new BitmapImage(new Uri(dtDItem.PathIco));
            mTextBlock.Content = dtDItem.Name;
            _contentLoaded = true;
        }
        private void DayItem_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ThatCheckBox.IsChecked = !ThatCheckBox.IsChecked;
        }
    }
}
