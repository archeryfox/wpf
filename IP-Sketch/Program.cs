using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IP_Sketch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
            Send();

            }
            //Get();

        }
        async static Task Get()
        {
            const string ip = "26.246.116.166";
            const int port = 8080;
            IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(IPep);
            socket.Listen(1000);
            while (true)
            {
                Socket Listener = socket.Accept();
                var Buffer = new byte[1024];
                int ReciveDataSize = 0;
                var getData = new StringBuilder();


                do
                {
                    ReciveDataSize = Listener.Receive(Buffer);
                    getData.Append(Encoding.UTF8.GetString(Buffer, 0, ReciveDataSize));
                } while (Listener.Available > 0);

                Console.WriteLine(getData);
                Listener.Send(Encoding.UTF8.GetBytes("Успех"));
                if (getData.Equals("/0"))
                {
                    Listener.Shutdown(SocketShutdown.Both);
                    Listener.Close();
                }
                await Task.Delay(100);
            }
        }
        async static Task Send()
        {
            while (true)
            {
                const string ip = "26.188.38.104";
                const int port = 8080;

                IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.Write("A:");

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
                await Task.Delay(10);
            }
        }
    }
}
