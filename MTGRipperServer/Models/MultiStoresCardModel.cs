using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MTGRipperServer.Models
{
    public class MultiStoresCardModel
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public string SetName { get; set; }

        public string Color { get; set; }

        public string Rarity { get; set; }

        public string ImageURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RarityString
        {
            get
            {
                switch (Rarity)
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