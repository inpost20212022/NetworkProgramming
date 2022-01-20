using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public static void StartServer()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            try
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);
                
                Console.WriteLine("Waiting for connection...");

                Socket handler = listener.Accept();
                // dane przychodzace
                string data = "";
                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1) break;
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
