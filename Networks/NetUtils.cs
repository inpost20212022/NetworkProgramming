using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace Networks
{
    internal class NetUtils
    {
        /// <summary>
        /// Wyświetla informacje o istniejących interfejsach sieciowych
        /// </summary>
        public void GetInterfaces()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Name: {0}", adapter.Name);
                Console.WriteLine("Status: {0}", adapter.OperationalStatus);
                Console.WriteLine("MAC: {0}", adapter.GetPhysicalAddress());
                if (adapter.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties props = adapter.GetIPProperties();
                    foreach (var prop in props.UnicastAddresses)
                    {
                        Console.WriteLine("Adres IP: {0}", prop.Address);
                    }
                    
                }
            }
        }

        /// <summary>
        /// Zamienia adres IP na nazwę domenową
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string GetHostFromIp(string ip)
        {
            IPHostEntry hostEntry= Dns.GetHostEntry(ip);
            return hostEntry.HostName;
        }


        /// <summary>
        /// Zwraca listę adresów IP na podstawie nazwy hosta
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public List<String> GetIpFromHost(string hostname)
        {
            List<String> ips = new List<String>();
            IPAddress[] ipaddress = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in ipaddress)
            {
                ips.Add(ip.ToString()); 
            }
            return ips;
        }

        public bool PingHost(string nameOrAddress)
        {
            bool isAlive = false;
            Ping ping = null;
            try
            {
                ping = new Ping();
                PingReply reply = ping.Send(nameOrAddress);
                isAlive = reply.Status == IPStatus.Success;
            } catch (PingException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (ping != null)
                {
                    ping.Dispose();
                    ping = null;
                }
            }
            return isAlive;
        }
    }
}
