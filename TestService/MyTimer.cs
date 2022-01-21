using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestService
{
    internal class MyTimer
    {
        Timer timer = new Timer();

        public void Start()
        {
            timer.Interval = 5000;
            WriteLog("Starting at "+DateTime.Now);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        public void Stop()
        {
            WriteLog("Stop at " + DateTime.Now);
            timer.Enabled = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteLog("Service alive " + DateTime.Now);
        }

        private void WriteLog(string s)
        {
            File.AppendAllText("c:/tmp/service_log.txt", s+"\r\n");
        }
    }
}
