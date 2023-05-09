using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chat
{
    public class ClientTCP
    {
        public Socket serverSocket;
        private static string ip;
        public ClientPage page;

        public ClientTCP(ClientPage page, string ip)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), 8888);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(ipe);
            ReciveMesg();
            this.page = page;
            ServerIsAvalible();
        }

        public List<UserMessage> Messages = new List<UserMessage>();
        IPEndPoint ipe;

        private async void ServerIsAvalible()
        {
            while (true)
            {
            await Task.Delay(100);
                if (!serverSocket.Connected)
                {
                    serverSocket.Disconnect(false);
                }
            }
        }
        private async Task ReciveMesg()
        {
            while (true)
            {
                byte[] bts = new byte[1480];
                await serverSocket.ReceiveAsync(bts, SocketFlags.None);
                string mesg = Encoding.UTF8.GetString(bts).Normalize();
                try
                {
                    page.Updating(new UserMessage("Юсер" + ServerTCP.Avas.Count, mesg, ServerTCP.Avas.Find(x => x.ip == ipe.Address.ToString())?.LGB));
                }
                catch
                {
                    //MessageBox.Show(exception.Message);
                }
            }
        }

        public async void Sends(string boxText)
        {

            byte[] bts = Encoding.UTF8.GetBytes(boxText);
            await serverSocket.SendAsync(bts, SocketFlags.None);
        }
    }
}
