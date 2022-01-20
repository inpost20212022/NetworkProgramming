using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebClientTest
{
    internal class CustomWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest req = base.GetWebRequest(uri);
            req.Timeout = Timeout;
            ((HttpWebRequest)req).ReadWriteTimeout = Timeout;
            return req;
        }
    }
}
