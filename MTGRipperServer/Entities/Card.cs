using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MTGRipperServer.Entities
{
    public class Card
    {
        private const string MTG_URL = "http://www.mtgprice.com";

        public int IdResult { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("fair_price")]
        public string Price { get; set; }

        [JsonProperty("setName")]
        public string SetName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("manna")]
        public string ManaCost { get; set; }

        [JsonProperty("fullImageUrl")]
        public string ImageURL { get; set; }

        [JsonProperty("setUrl")]
        public string SetURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RarityString
        {
            get
            {
                switch(Rarity)
                {                    
                    case "C":
                        return "Common";
                    case "U":
                        return "Uncommon";
                    case "R":
                        return "Rare";
                    case "M":
                        return "Mythic Rare";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ManaStringClass
        {
            //TODO: Support mana cost images
            get
            {
                return ManaCost;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MTGPriceURL
        {
            //TODO: Support mana cost images
            get
            {
                return MTG_URL + URL;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SetURLString
        {
            get
            {
                return MTG_URL + SetURL;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PriceString
        {
            get
            {
                string actualPrice = Price;
                string[] parts = actualPrice.Split('.');

                if (parts.Length == 2)
                {
                    if (parts[1].Length == 1)
                    {
                        return actualPrice + "0 $";
                    }
                }

                return actualPrice + " $";
            }
        }
    }
}