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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage(string ip_con)
        {
            InitializeComponent();
            client = new ClientTCP(this, ip_con);
        }

        public void Updating(UserMessage userMessage)
        {
            ((Application.Current.MainWindow as MainWindow).Framer.Content as ClientPage).Chat.Items.Add(userMessage);
        }
        
        public ClientTCP client;
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            client.Sends(Box.Text);
        }
    }
}
