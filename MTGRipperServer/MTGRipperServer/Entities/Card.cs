using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTGRipperServer.Entities
{
    public class Card
    {
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


    }
}