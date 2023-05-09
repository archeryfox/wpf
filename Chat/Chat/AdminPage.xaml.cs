using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        public AdminPage(ServerTCP server)
        {
            InitializeComponent();
        }
        public ServerTCP server = new ServerTCP();
        ClientTCP client = new ClientTCP(new ClientPage(), "127.0.0.1");
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            client.Sends(Box.Text);
          
        }

        ~AdminPage()
        {
            server.socket.Dispose();
        }
    }
}
