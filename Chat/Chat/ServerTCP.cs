using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;


namespace Chat
{
    public class ServerTCP
    {
        public List<Socket> CurrentClients = new List<Socket>();
        public Socket socket;
        public static List<UserAva> Avas = new List<UserAva>();
        public ServerTCP()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ip);
            socket.Listen(100);
            Avas.Add(new UserAva(socket.LocalEndPoint.ToString()));
            AwaitConnection();
        }

        CancellationTokenSource yamanka = new CancellationTokenSource();
        private async Task AwaitConnection()
        {
            while (!yamanka.IsCancellationRequested)
            {
                Socket conneectedSocket = await socket.AcceptAsync();
                CurrentClients.Add(conneectedSocket);
                Avas.Add(new UserAva(conneectedSocket.LocalEndPoint.ToString()));
                ReciveMesg(conneectedSocket);
            }
        }

        private async Task ReciveMesg(Socket sockety)
        {
            while (true)
            {
                byte[] bts = new byte[1480];
                await sockety.ReceiveAsync(bts, SocketFlags.None);
                string mesg = Encoding.UTF8.GetString(bts);
                ((Application.Current.MainWindow as MainWindow).Framer.Content as AdminPage).Chat.Items.Add(new Chat.UserMessage("Юсер" + 1, mesg, Avas.Find(x => x.ip == sockety.LocalEndPoint.ToString()).LGB));
                foreach (var Cclien in CurrentClients)
                {
                    Sends(mesg, Cclien);
                }
            }
        }
        public async void Sends(string msg, Socket sendSocket)
        {
            byte[] bts = Encoding.UTF8.GetBytes(msg);
            await sendSocket.SendAsync(bts, SocketFlags.None);
        }
        ~ServerTCP()
        {
            yamanka.Cancel();
            socket.Dispose();
        }
    }
}
