using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IP_Client
{
    internal class Program
    {
        static async void Geting()
        {
            await Task.Delay(100);
        }   
        static void Main(string[] args)
        {
            Console.Title = "Клиент";

            #region TCP Test
            const string ip = "26.188.38.104";
            //комп
            const int port = 8080;

            while (true)
            {
                try
                {
                    IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(ip), port);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    socket.ConnectAsync(IPep);
                    Console.Write("I:");
                    string mesg = Console.ReadLine();
                    var Data = Encoding.UTF8.GetBytes(mesg);
                    socket.Send(Data);

                    var Buffer = new byte[1024];
                    int ReciveDataSize = 0;
                    var Anwser = new StringBuilder();

                    do
                    {
                        ReciveDataSize = socket.Receive(Buffer);
                        Anwser.Append(Encoding.UTF8.GetString(Buffer, 0, ReciveDataSize));
                    } while (socket.Available > 0);

                    Console.WriteLine(Anwser.ToString());
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                } finally { }
            }
            #endregion
        }
    }
}
