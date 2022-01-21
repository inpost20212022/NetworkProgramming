using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SocketServerMulti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(delegate()
            {
                new Server("127.0.0.1", 11_000);
            });
            thread.Start();

            Console.ReadKey();
        }
    }
}
