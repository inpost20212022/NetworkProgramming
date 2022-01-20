using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetUtils netUtils = new NetUtils();
            //netUtils.PingHost("194.204.159.1");
            //netUtils.PingHost("www.wp.pl");
            //netUtils.GetHostFromIp("194.204.159.1");
            //netUtils.GetIpFromHost("www.google.com");
            netUtils.GetInterfaces();
            Console.ReadKey();
        }
    }
}
