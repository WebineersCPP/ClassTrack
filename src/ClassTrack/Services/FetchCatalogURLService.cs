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
            return collegeURL;

        }
        public string findCollegeURL(string catalog, string college)
        {
            //Find college
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(catalog);
            var root = doc.DocumentNode;
            var htmlNodes = root.DescendantsAndSelf();

            // Search through fetched html nodes for relevant information
            int counter = 0;
            foreach (HtmlNode node in htmlNodes) {
                string linkName = node.InnerText;
                if (linkName == colleges[college] )//&& counter == 0
                {
                    string targetURL = node.Attributes["href"].Value;
                    return targetURL;
                }  
                else if(linkName == colleges[college] && counter == 1)
                {
                    string targetURL = "found it!"; //node.Attributes["href"].Value;
                    return targetURL;
                }/* */
            }

            return "DID NOT WORK";
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
                // Do something with response. Example get content:
                var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                return responseContent;
            }

            return "FAIL";

        }
    }
}
