using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SimpleSocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartClient();
            Console.ReadKey();
        }

        public static void StartClient()
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                //gniazdo TCP/IP
                Socket socket =new Socket(AddressFamily.InterNetwork, 
                    SocketType.Stream, ProtocolType.Tcp);
                
                socket.Connect(remoteEP); //podłączenie do serwera
                Console.WriteLine("Socket connected...");

                String s = "Ala ma kota!<EOF>";
                byte[] msg = Encoding.UTF8.GetBytes(s);

                int bytesSent = socket.Send(msg);  //wysylka danych

                byte[] bytes = new byte[1024];
                int bytesRec = socket.Receive(bytes);
                Console.WriteLine("Received txt = {0}", 
                    Encoding.UTF8.GetString(bytes, 0, bytesRec));

                // zwolnijmy zasoby
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
