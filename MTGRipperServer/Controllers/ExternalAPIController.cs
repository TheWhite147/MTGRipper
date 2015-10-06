using MTGRipperServer.Entities;
using MTGRipperServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MTGRipperServer.Controllers
{
    public class ExternalAPIController : Controller
    {
        private static string API_URL = "http://www.mtgprice.com/cardNameSearch?name=";
        private static string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";

        //
        // GET: /ExternalAPI/
        [HttpGet]
        public ActionResult SearchResults(string searchTerms)
        {           
            SearchResultsModel model = new SearchResultsModel();
            string jsonResponse = string.Empty;
            List<Card> lstCards = new List<Card>();

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

                lstCards = JsonConvert.DeserializeObject<List<Card>>(jsonResponse);

                // Assign IDs to cards
                for (int i = 0; i < lstCards.Count; i++)
                {
                    lstCards[i].IdResult = i + 1; // Starts at 1
                }
                
                model.LstCards = lstCards;
            }
            catch(Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }

            return View(model);
        }

    }
}
