using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public partial class ServiceTest : ServiceBase
    {
        MyTimer myTimer = new MyTimer();
        public ServiceTest()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myTimer.Start();
        }

        protected override void OnStop()
        {
            myTimer.Stop();
        }
    }
}
