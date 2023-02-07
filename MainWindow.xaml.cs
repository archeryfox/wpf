﻿using System;
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
        /// <summary>
        /// Номер хода
        /// </summary>
        public static int turn = 0;

        public static int GameNum = 1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            List<string> ContentCollection = XOs.Children.OfType<Button>().Select(x => x.Content.ToString()).ToList();
            List<Button> GridButtons = XOs.Children.OfType<Button>().ToList();
            Debox.Text = null;
            Player.Sym = GameNum % 2 == 0 ? "X" : "0";
            Robot.Sym = GameNum % 2 == 0 ? "0" : "X";
            GameNum++;

            for (int i = 0; i < GridButtons.Count; i++)
            {
                var ell = GridButtons[i];
                ell.Content = "\n\n" + (i + 1);
                ell.IsEnabled = true;
            }
            foreach (var item in ContentCollection)
            {
                Debox.Text += item;
            }

        }
        private void XO_Click(object sender, RoutedEventArgs e)
        {
            var B = sender as Button;
            List<string> ContentCollection = XOs.Children.OfType<Button>().Select(x => x.Content.ToString()).ToList();
            List<Button> GridButtons = XOs.Children.OfType<Button>().ToList();
            TurnCheck(B);
            Robot.RoboTurn(GridButtons);
            string[,] buts =
            {
                {UL.Content.ToString(),U.Content.ToString(),UR.Content.ToString()},
                {L.Content.ToString(),C.Content.ToString(),R.Content.ToString()},
                {DL.Content.ToString(),D.Content.ToString(),DR.Content.ToString()}
            };

            bool win = (buts[0, 0] == "X" && buts[1, 1] == "X" && buts[2, 2] == "X") ||
                (buts[0, 0] == "0" && buts[1, 1] == "0" && buts[2, 2] == "0") ||
                ((buts[0, 0] == "X" && buts[1, 0] == "X" && buts[2, 0] == "X") ||
                (buts[0, 0] == "0" && buts[1, 0] == "0" && buts[2, 0] == "0")) ||
                ((buts[0, 2] == "X" && buts[1, 1] == "X" && buts[2, 0] == "X") ||
                (buts[0, 2] == "0" && buts[1, 1] == "0" && buts[2, 0] == "0") ||
                ((buts[0, 1] == "X" && buts[1, 1] == "X" && buts[2, 1] == "X") ||
                (buts[1, 1] == "0" && buts[1, 2] == "0" && buts[1, 0] == "0")) ||
                ((buts[2, 2] == "X" && buts[1, 2] == "X" && buts[0, 2] == "X") ||
                (buts[2, 2] == "0" && buts[1, 2] == "0" && buts[0, 2] == "0")) ||
                (buts[0, 0] == "X" && buts[0, 1] == "X" && buts[0, 2] == "X") ||
                (buts[0, 0] == "0" && buts[0, 1] == "0" && buts[0, 2] == "0") ||
                (buts[1, 0] == "X" && buts[1, 1] == "X" && buts[1, 2] == "X") ||
                (buts[1, 0] == "0" && buts[1, 1] == "0" && buts[1, 2] == "0") ||
                (buts[2, 0] == "X" && buts[2, 1] == "X" && buts[2, 2] == "X") ||
                (buts[2, 0] == "0" && buts[2, 1] == "0" && buts[2, 2] == "0"));

            if (win)
            {
                for (int i = 0; i < GridButtons.Count; i++)
                {
                    var ell = GridButtons[i];
                    ell.IsEnabled = false;
                }
                if (B.Content == "0")
                {
                    MessageBox.Show($"Выиграли нолики!");
                }
                else if (B.Content == "X")
                {
                    MessageBox.Show($"Выиграли крестики!");
                }
                win = false;
            }
            else if (!win)
            {
                TieCheck(buts);
            }
            Player.Turn = true;
            Robot.Turn = false;
        }

        private void XOs_Initialized(object sender, EventArgs e)
        {
            List<Button> Gr = XOs.Children.OfType<Button>().ToList();
            const string _null = "";
            for (int i = 0; i < Gr.Count; i++)
            {
                var ell = Gr[i];
                ell.IsEnabled = false;
            }
        }

        void TieCheck(string[,] field, bool win = false)
        {
            int i = 0;
            foreach (var item in field)
            {
                i += item == "X" || item == "0" ? 1 : 0;
            }
            if (i == field.Length)
            {
                List<Button> Gr = XOs.Children.OfType<Button>().ToList();
                const string _null = "";
                MessageBox.Show("Ничья!");
                for (int f = 0; f < Gr.Count; f++)
                {
                    var ell = Gr[f];
                    ell.Content = _null;
                    ell.IsEnabled = false;
                    i = 0;
                }
            }
        }

        void TurnCheck(Button b)
        {
            List<Button> BLIst = XOs.Children.OfType<Button>().Where(x => x.Content != "X" && x.Content != "0").ToList();
            if (b.Content != "X" || b.Content != "0")
            {
                b.Content = Player.Sym;
                b.IsEnabled = false;
            }
        }
    }
}