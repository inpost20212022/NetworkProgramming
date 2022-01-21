using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace SocketServerMulti
{
    internal class Server
    {
        TcpListener server = null;

        public Server(string ip, int port)
        {
            server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
            StartListener();
        }

        private void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                    t.Start(client);
                }
            } catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleClient(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            try
            {

                byte[] bytes = new byte[1024];
                int i;
                StringBuilder sb = new StringBuilder();
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    sb.Append(Encoding.UTF8.GetString(bytes, 0, i));
                }
                Console.WriteLine("{1} - Received text: {0}", sb.ToString(), Thread.CurrentThread.ManagedThreadId);

                byte[] reply = Encoding.UTF8.GetBytes(sb.ToString().ToLower());
                stream.Write(reply, 0, reply.Length);
                Console.WriteLine("{0} - Sent data", Thread.CurrentThread.ManagedThreadId);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Close();
            }

        }
    }
}
