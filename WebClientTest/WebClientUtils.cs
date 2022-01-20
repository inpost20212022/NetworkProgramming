using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace WebClientTest
{
    internal class WebClientUtils
    {

        public string PostUrlAsString()
        {
            string result = null;
            using (WebClient webClient = new WebClient())
            {
                string url = "http://httpbin.org/post";

                NameValueCollection data = new NameValueCollection();
                data["username"] = "test1";
                data["password"] = "tajne_haslo";
                byte[] arr = webClient.UploadValues(url, "POST", data);

                result = Encoding.UTF8.GetString(arr);
            }
            return result;
        }

        public string GetUrlAsString(string url)
        {
            string result = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", 
                    "String odpowiedzialny za identyfikacje przegladarki");
                //byte[] arr = webClient.DownloadData(url);
                //// zamiana tablicy bajtow na string
                //result = Encoding.UTF8.GetString(arr, 0, arr.Length);

                result = webClient.DownloadString(url);
            }
            return result;
        }

        public string GetUrlAsStringTimeout(string url, int timeoutSec)
        {
            string result = null;
            using (CustomWebClient webClient = new CustomWebClient())
            {
                webClient.Timeout = timeoutSec * 1000;
                result = webClient.DownloadString(url);
            }
            return result;
        }

        public void DownloadFile(String url, String localFile)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, localFile);
            }
        }


        public void GetUrlAsStringAsync(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
                webClient.DownloadStringAsync(new Uri(url));
            }
        }

        private void WebClient_DownloadStringCompleted(object sender, 
            DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("Result = {0}", e.Result);
        }
    }
}
