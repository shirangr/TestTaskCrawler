using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TestTaskCrawler.LogicLayer
{
    public class Downloader
    {
        private readonly HttpClient _httpClient;

        public Downloader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static string GetHtmlByUrl(Uri urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader readStream = null;

            try
            {
                if (response.StatusCode == HttpStatusCode.OK) //success
                {
                    Stream receiveStream = response.GetResponseStream(); 

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    
                    return readStream.ReadToEnd(); //get html page data
                }

                return "";
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                response.Dispose();
                readStream.Dispose();
                response.Close();
                readStream.Close();
            }
        }
    }
}
