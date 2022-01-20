using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FtpClientTest
{
    internal class FtpUtils
    {
        string username = "anonymous";
        string password = "xyz@host.pl";


        public void Download(string remoteFile, string fileName)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(remoteFile);
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UsePassive = false;
                ftpRequest.UseBinary = true;

                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                Stream streamReader = response.GetResponseStream();

                byte[] buffer = new byte[response.ContentLength];
                streamReader.Read(buffer, 0, (int)response.ContentLength);

                File.WriteAllBytes(fileName, buffer);

                streamReader.Close();
                response.Close();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<String> GetFtpFiles(string folderPath)
        {
            List<String> files = new List<String>();

            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderPath);
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpRequest.UsePassive = false;

                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                string line = streamReader.ReadLine();
                while (!String.IsNullOrEmpty(line))
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return files;
        }
    }
}
