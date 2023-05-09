using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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

namespace Chat
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

        private int c = 0;

        private void MainWindow_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((Application.Current.MainWindow as MainWindow).Framer.Content as AdminPage).Box.Text = "";
            }
        }

        private void CreateChat_OnClick(object sender, RoutedEventArgs e)
        {
            Boerder.Children.Clear();

            Framer.Content = new AdminPage();
        }

        private void JoinChat_OnClick(object sender, RoutedEventArgs e)
        {
            Boerder.Children.Clear();
            Framer.Content = new ClientPage(Ipsk.Text);
        }

        private void MainWindow_OnClosing(object? sender, CancelEventArgs e)
        {
            if (Framer.Content != null)
                new MainWindow().Show();
            if ((Application.Current.MainWindow as MainWindow).Framer.Content is ClientPage)
            {
                //MessageBox.Show("Client");
            }
            else if ((Application.Current.MainWindow as MainWindow).Framer.Content is AdminPage)
            {
                ((Application.Current.MainWindow as MainWindow).Framer.Content as AdminPage).server.socket.Disconnect(true);
                ((Application.Current.MainWindow as MainWindow).Framer.Content as AdminPage).server.socket.Dispose();
                //MessageBox.Show("Admin");
            }
        }
    }
}
