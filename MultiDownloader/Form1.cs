using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int totalBytes = 0;
        string baseURL = "http://51.91.120.89/TABLICE/";
        List<Task> tasks = new List<Task>();

        private async void btnStart_Click(object sender, EventArgs e)
        {
            lbUrl.Items.Clear(); //usuwanie starej zawartosci listbox'a

            WebClient wb = new WebClient();
            string content = wb.DownloadString(baseURL);
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                string imageFile = line.Trim();
                if (String.IsNullOrEmpty(imageFile)) continue;

                Task task = Task.Run(() => {
                    string url = $"{baseURL}{imageFile}";
                    WebClient client = new WebClient();
                    byte[] data = client.DownloadData(url);
                    using (FileStream fs = new FileStream($"c:/tmp/{imageFile}", FileMode.Create))
                    {
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                        //totalBytes += data.Length;
                        Interlocked.Add(ref totalBytes, data.Length);
                    }
                    //lbUrl.Items.Add(url);
                    lbUrl.Invoke(new Action(() => { lbUrl.Items.Add(url); } ));

                });
                tasks.Add(task);
            }

            //uruchomienie listy zadań do wykonania
            //Task.WaitAll(tasks.ToArray());
            await Task.WhenAll(tasks);
            MessageBox.Show($"Total bytes: {totalBytes}");
        }
    }
}
