using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClientTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClientUtils wct = new WebClientUtils();
            //String s = wct.GetUrlAsString("http://51.91.120.89/TABLICE/");
            //Console.WriteLine(s);
            //wct.DownloadFile("http://51.91.120.89/TABLICE/AB0122BK.jpg", "c:/tmp/test.jpg");
            //wct.GetUrlAsStringAsync("http://51.91.120.89/TABLICE/");
            //wct.GetUrlAsStringTimeout("http://51.91.120.89/TABLICE/", 10);
            wct.PostUrlAsString();
            Console.WriteLine("Start downloading....");
            Console.ReadKey();

        }
    }
}
