using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            const string ip = "26.188.38.104";
            const int port = 8080;

            IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("I:");
            
            string mesg = Console.ReadLine();

            var Data = Encoding.UTF8.GetBytes(mesg);
            socket.Connect(IPep);
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
            Console.ReadLine();
        }
    }
}
