using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        static bool IsNumered = false;
        static bool First = true;
        /// <summary>
        ///  Лист с номерами
        /// </summary>
        static List<string> lists = new List<string>();
        
        /// <summary>
        /// Лист только со словами
        /// </summary>
        static List<string> conts = new List<string>() { };

        /// <summary>
        /// Скрипт, нумирующий элементы внутри ListBox'a
        /// </summary>
        private void MagicNumerator(object sender, RoutedEventArgs e)
        {
            LBX.FontSize = 36;
            var cont = "";
            if (First)
            {
                for (int a = 0; a < LBX.Items.Count; a++)
                {
                    for (int b = 0; b < LBX.Items[a]?.ToString().Length; b++)
                    {
                        if (LBX.Items[a].ToString()[b] == LBX.Items[a].ToString()[37])
                        {
                            cont = String.Empty;
                            for (int c = b; c < LBX.Items[a]?.ToString().Length; c++)
                            {
                                cont += LBX.Items[a].ToString()[c];
                            }
                            conts.Add(cont);
                        }
                    }
                    lists.Add($"{a + 1}. {cont}");
                }
                LBX.Items.Clear();
                LBX.ItemsSource = lists;
                First = false;
                IsNumered = true;
            }
            else if (!First && IsNumered)
            {
                for (int a = 0; a < LBX.Items.Count; a++)
                {
                    for (int b = 0; b < LBX.Items[a]?.ToString().Length; b++)
                    {
                        if (LBX.Items[a].ToString()[1] == '.')
                        {
                            cont = String.Empty;
                            for (int c = b; c < LBX.Items[a]?.ToString().Length; c++)
                            {
                                cont += LBX.Items[a].ToString()[c];
                            }
                            conts.Add(cont);
                        }
                    }
                }
                lists = conts;
                LBX.ItemsSource = lists;
                IsNumered = false;
            }
            else if (!First && !IsNumered)
            {
                for (int a = 0; a < LBX.Items.Count; a++)
                {
                    for (int b = 0; b < LBX.Items[a]?.ToString().Length; b++)
                    {
                        if (LBX.Items[a].ToString()[1] != '.')
                        {
                            cont = String.Empty;
                            for (int c = b; c < LBX.Items[a]?.ToString().Length; c++)
                            {
                                cont += LBX.Items[a].ToString()[c];
                            }
                        }
                        conts.Add(cont);
                    }
                    lists.Add($"{a + 1}. {cont}");
                }
                LBX.ItemsSource = lists;
            }

        }

        private void Ex_Click(object sender, RoutedEventArgs e)
        {
            var s = "";
            foreach (var item in lists)
            {
                s += item.ToString() + "\n";
            }
            var s2 = "";
            foreach (var item in conts)
            {
                s2 += item.ToString() + "\n";
            }
            dbglog1.Text = $"{s}\n{s2}";

        }


      
    }
}
