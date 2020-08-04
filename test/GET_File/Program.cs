using System;
using System.IO;
using System.Net;

namespace GET_File
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
             
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.68.234:21/");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;


                request.Credentials = new NetworkCredential("test", "123456");
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
