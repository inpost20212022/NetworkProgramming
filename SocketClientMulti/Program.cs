using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketClientMulti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(delegate ()
            {
                Connect("127.0.0.1", 11_000, "ABCDED");
            }).Start();

            new Thread(delegate ()
            {
                Connect("127.0.0.1", 11_000, "XXXXXXX");
            }).Start();

            new Thread(delegate ()
            {
                Connect("127.0.0.1", 11_000, "WWWWWWW");
            }).Start();

            Console.ReadKey();
        }

        static void Connect(String ip, int port, String message)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();

                byte[] bytes = Encoding.UTF8.GetBytes(message);
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Sent: {0}", message);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                if (stream != null) stream.Close();
                if (client != null) client.Close();
            }
        }
    }
}
