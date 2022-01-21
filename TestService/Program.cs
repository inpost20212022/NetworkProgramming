using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            if (System.Environment.UserInteractive)
            {
                MyTimer myTimer = new MyTimer();
                myTimer.Start();
                while (true) { }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ServiceTest()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
