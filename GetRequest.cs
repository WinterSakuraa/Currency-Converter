using System;
using System.IO;
using System.Net;

namespace Privat24_API
{
    public class GetRequest
    {
        HttpWebRequest request;
        string address;

        public string Response { get; set; }

        public GetRequest(string address)
        {
            this.address = address;
        }

        public void Run()
        {
            request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

