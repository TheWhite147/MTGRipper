using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTGRipperServer.Helpers
{
    public static class HtmlParser
    {
        public static string ParsePrice3KL(string html)
        {
            string price = string.Empty;
            string spanText = "<span class=\"offers";

            html = html.Replace("\n", "").Replace("\t", "").Replace("\r","");

            int indexSpanStart = html.IndexOf(spanText);
            html = html.Remove(0, indexSpanStart + spanText.Length).Trim();

            string cadText = "CAD$";
            int indexCAD = html.IndexOf(cadText);
            html = html.Remove(0, indexCAD + cadText.Length);

            int indexSpanEnd = html.IndexOf("</span>");
            html = html.Remove(indexSpanEnd).Trim();
                        
            price = html.Replace("CAD$", "");

            if (string.IsNullOrEmpty(price))
                price = "N/A";
            else
                price = price + "$";

            return price;
        }
    }
}