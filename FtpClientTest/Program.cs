using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClientTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FtpUtils ftpUtils = new FtpUtils();
            //ftpUtils.GetFtpFiles("ftp://3.120.133.208/pub");
            ftpUtils.Download("ftp://3.120.133.208/pub/access.log", "c:/tmp/access.txt");

            Console.ReadKey();
        }
    }
}
