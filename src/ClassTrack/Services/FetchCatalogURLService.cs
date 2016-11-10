using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using ClassTrack.Models;
using System.Net;
using HtmlAgilityPack;

namespace ClassTrack.Services
{
    public class FetchCatalogURLService
    {
        public async Task<string> ReturnUrl(string major, string year, string subplan = null)
        {
            HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument html;

            try
            {
                html = await new HtmlWeb().LoadFromWebAsync(http://catalog.cpp.edu/);
            }
            catch (Exception e)
            {
                throw new Exception("Error loading url");
            }

            var root = html.DocumentNode;
            var htmlNodes = root.Descendants();

            foreach (HtmlNode node in htmlNodes)
            {
                if(node.Name == "select_catalog")
                {

                }
            }
        }
    }
}
