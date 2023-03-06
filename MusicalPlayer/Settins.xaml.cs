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
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MusicalPlayer
{
    /// <summary>
    /// Логика взаимодействия для Settins.xaml
    /// </summary>
    public partial class Settins : Window
    {
        MainWindow NewMAin = new MainWindow();
        public Settins()
        {
            InitializeComponent();
            Path.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        }

      
    }
}
