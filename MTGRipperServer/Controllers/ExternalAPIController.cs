using MTGRipperServer.Entities;
using MTGRipperServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static string PRICE_API_URL = "http://www.mtgprice.com/cardNameSearch?name=";
        private static string CURRENCY_API_URL = "http://currency-api.appspot.com/api/USD/CAD.jsonp?amount=1.00&callback=USDRate";

        private static string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
        
        //
        // GET: /ExternalAPI/
        [HttpGet]
        public ActionResult SearchResults(string searchTerms)
        {
            Stopwatch totalTimer = new Stopwatch();
            Stopwatch apiTimer = new Stopwatch();
            totalTimer.Start();

            SearchResultsModel model = new SearchResultsModel();
            string jsonResponse = string.Empty;
            List<Card> lstCards = new List<Card>();

            try
            {
                searchTerms = searchTerms.Replace(' ', '+');
                string urlOutput = PRICE_API_URL + searchTerms;

                var request = WebRequest.Create(urlOutput) as HttpWebRequest;
                request.Host = "www.mtgprice.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";

                apiTimer.Start();
                WebResponse response = request.GetResponse();
                apiTimer.Stop();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                jsonResponse = reader.ReadToEnd();

                lstCards = JsonConvert.DeserializeObject<List<Card>>(jsonResponse);

                // Assign IDs to cards
                for (int i = 0; i < lstCards.Count; i++)
                {
                    lstCards[i].IdResult = i + 1; // Starts at 1
                }
                
                model.LstCards = lstCards;
                totalTimer.Stop();

                model.APIResponseTime = apiTimer.ElapsedMilliseconds;
                model.TotalResponseTime = totalTimer.ElapsedMilliseconds;
            }
            catch(Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }

            return View(model);
        }

        //
        // GET: /ExternalAPI/
        [HttpGet]
        public ContentResult GetCurrency()
        {
            string jsonResponse = string.Empty;

            try
            {
                var request = WebRequest.Create(CURRENCY_API_URL) as HttpWebRequest;
                request.Host = "www.currency-api.appspot.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                
                WebResponse response = request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                jsonResponse = reader.ReadToEnd();

                jsonResponse = jsonResponse.Replace("USDRate", "").Replace("(", "").Replace(")", "");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }

            return Content(jsonResponse);
        }
    }
}
