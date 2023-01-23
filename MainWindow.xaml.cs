using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace XO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public int turn 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> Coll = XOs.Children.OfType<Button>().Select(x => x.Content.ToString()).ToList();
            List<Button> Gr = XOs.Children.OfType<Button>().ToList();
            Debox.Text = null;
            for (int i = 0; i < Gr.Count - 1; i++)
            {
                var ell = Gr[i];
                ell.Content = " ";
            }
            foreach (var item in Coll)
            {
                Debox.Text += item;
            }
        }
        private void XO_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;

            if (b.Content == "0")
            {
                b.Content = "X";
            }
            else
            {
                b.Content = "0";
            }
            string[,] buts =
            {
                {UL.Content.ToString(),U.Content.ToString(),UR.Content.ToString()},
                {L.Content.ToString(),C.Content.ToString(),R.Content.ToString()},
                {DL.Content.ToString(),D.Content.ToString(),DR.Content.ToString()}
            };
            bool winU = (buts[0, 0] == buts[0, 1]) && (buts[0, 2] == buts[0, 1]);
            bool winC = (buts[1, 0] == buts[1, 1]) && (buts[1, 2] == buts[1, 1]);
            bool winD = (buts[2, 0] == buts[2, 1]) && (buts[2, 2] == buts[2, 1]);
            var win = winC || winD || winU;
            if ((buts[0, 0] == "") && (buts[0, 2] == "") && buts[0, 1] == "")
            {
                winU = false; 

            }
            if ((buts[1, 0] == "") && (buts[1, 2] == "") && buts[1, 1] == "")
            {
                winC = false;

            }
            if ((buts[2, 0] == "") && (buts[2, 2] == "") && buts[2, 1] == "")
            {
                winC = false;

            }
            if (winC)
            {
                if (b.Content == "0")
                {
                    MessageBox.Show($"Выиграли нолики!");
                }
                else if (b.Content == "X")
                {
                    MessageBox.Show($"Выиграли крестики!");
                }
            }

        }

        private void War(object sender, MouseEventArgs e)
        {
            /*  bool win = (U.Content == C.Content) && (D.Content == C.Content);
              if (win)
              {
                  MessageBox.Show("центральная ветка");
              }*/
        }

        private void XOs_Initialized(object sender, EventArgs e)
        {
            List<Button> Gr = XOs.Children.OfType<Button>().ToList();
            for (int i = 0; i < Gr.Count; i++)
            {
                var ell = Gr[i];
                ell.Content = ".";
            }
        }
    }
}
