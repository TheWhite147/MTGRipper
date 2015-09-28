using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MTGRipperServer.Helpers
{
    public static class RemoteAPIHelper
    {
        private static string API_URL = "http://www.mtgprice.com/cardNameSearch?name=";
        private static string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";

        public static string GetCardsInfo(string searchTerms)
        {
            string jsonResponse = string.Empty;

            try
            {
                searchTerms = searchTerms.Replace(' ', '+');
                string urlOutput = API_URL + searchTerms;

                var request = WebRequest.Create(urlOutput) as HttpWebRequest;
                request.Host = "www.mtgprice.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                WebResponse response = request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                jsonResponse = reader.ReadToEnd();
            }
            catch(Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }

            return jsonResponse;
        }
    }
}