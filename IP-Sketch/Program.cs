using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IP_Sketch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "192.168.56.1";
            //Ноут
            Console.Title = "Сервак";
            const int port = 8080;
            IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(IPep);
            socket.Listen(1000);

            while (true)
            {
                Console.WriteLine("cdc");
                Socket Listener = socket.Accept();
                var Buffer = new byte[1024];
                int ReciveDataSize = 0;
                var Data = new StringBuilder();

                do
                {
                    ReciveDataSize = Listener.Receive(Buffer);
                    Data.Append(Encoding.UTF8.GetString(Buffer, 0, ReciveDataSize));
                } while (Listener.Available > 0);

                Console.WriteLine(Data);
                Listener.Send(Encoding.UTF8.GetBytes("Успех1"));

                //Listener.Shutdown(SocketShutdown.Both);
                //Listener.Close();
            }
        }
    }
}
