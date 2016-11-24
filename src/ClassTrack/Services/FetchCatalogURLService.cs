using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using ClassTrack.Models;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Text;
using System.Collections;

namespace ClassTrack.Services
{
    public class FetchCatalogURLService
    {
        private Dictionary<string, string> catalogYears = new Dictionary<string, string>
        {
            { "2012", "4" },
            { "2013", "5" },
            { "2014", "9" },
            { "2015", "8" },
            { "2016", "10"}
        };

        private Dictionary<string, string> colleges = new Dictionary<string, string>
        {
            { "CLASS", "College of Letters, Arts, and Social Sciences" },
            { "AG", "College of Agriculture" },
            { "BUS", "College of Business Administration" },
            { "CEIS", "College of Education and Integrative Studies" },
            { "ENG", "College of Engineering"},
            { "ENV", "College of Environmental Design" },
            { "SCI", "College of Science" },
            { "HRT", "The Collins College of Hospitality Management" }
        };

        public async Task<string> GetMajorPlanUrl(string major, string college, string year, string subplan = null)
        { 
            string catalog = await chooseCatalogYear(year);
            string collegeURL = findCollegeURL(catalog, college);
            string majorURL = findMajorURL(collegeURL, major);
            return majorURL;
        }

        public string findMajorURL(string collegeURL, string major)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(collegeURL);
            var root = doc.DocumentNode;
            var htmlNodes = root.Descendants();
            //Find html node containing the major heading
            foreach(HtmlNode node in htmlNodes)
            {
                if (node.InnerText == major)
                {
                    HtmlNode target = node.NextSibling;
                    List<string> links = target.Descendants("a").Select(a => a.Attributes["href"].Value).ToList();
                    return links.First()+ "__IT WORKED__";
                }
            }

            
            return "NoPE"; //+links.First().ToString();
        }
        
        //Find correct web link for given college
        public string findCollegeURL(string catalog, string college)
        {
            
            //Load catalog HTML Document
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(catalog);
           
            //Find HTML node with Inner Text matching college name
            var links = doc.DocumentNode.Descendants("a").Where(a => a.InnerText == colleges[college])
               .Select(a => a.Attributes["href"].Value)
               .ToList();

            return "http://catalog.cpp.edu" + links[1];
        } 

        public async Task<string> chooseCatalogYear(string year) 
        {
            
            // Post to catalog website to choose catalog year
            HttpClient client = new HttpClient();
            string catalogURL = "http://catalog.cpp.edu/index.php";

            //Example choose 2015/16 catalog (value = "8")
            //input parameter for drop down box in catalog
            var parameter = new Dictionary<string,string>{
                { "catalog", catalogYears[year] },
                { "sel_cat_submit", "GO" }
            };
            var encodedContent = new FormUrlEncodedContent(parameter);
            var response = await client.PostAsync(catalogURL, encodedContent).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Return response, which is an HTML string
                var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                return responseContent;
            }

            return "FAIL";

        }
    }
}
