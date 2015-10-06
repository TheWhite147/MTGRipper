using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTGRipperServer.Entities;

namespace MTGRipperServer.Models
{
    public class SearchResultsModel
    {
        public List<Card> LstCards { get; set; }

        public long TotalResponseTime { get; set; }
        public long APIResponseTime { get; set; }

        public long LocalResponseTime
        {
            get
            {
                return TotalResponseTime - APIResponseTime;
            }
        }
    }
}