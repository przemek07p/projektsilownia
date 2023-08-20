using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using projekt003.Models;
using System.Text;

namespace projekt003.Buisness
{
    public class WebApiMethods : IDisposable
    {
        public void Dispose()
        {

        }


        public string GetMeal(string url, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.AllowReadStreamBuffering = false;
            
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(responseStream))
                        {
                            string jsonResponse = sr.ReadToEnd();
                            var x =  jsonResponse;
                            return x;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                throw e;
            }

        }

    }
}
