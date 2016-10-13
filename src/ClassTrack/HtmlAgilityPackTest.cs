using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;

namespace ClassTrack
{
    public class HtmlAgilityPackTest
    {
        public async void getTextFromWebpage()
        {

            string htmlPage;
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync("http://www.cpp.edu/");
            }

            HtmlDocument myDocument = new HtmlDocument();
            myDocument.LoadHtml(htmlPage);

            //this line results an error @ "SelectNodes"
            var metaTags = myDocument.DocumentNode.Descendants("//meta");



            //string url = "http://www.cpp.edu/";
            //var Webget = new HtmlWeb();
            //var doc = Webget.LoadFromWebAsync(url);
            //foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h3//a"))
            //{
            //    names.Add(node.ChildNodes[0].InnerHtml);
            //}
            //foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='tel']//a"))
            //{
            //    phones.Add(node.ChildNodes[0].InnerHtml);
            //}


            //HtmlWeb web = new HtmlWeb();
            //var doc = await Task.Factory.StartNew( ()=> web.LoadFromWebAsync("http://www.cpp.edu/"));
            //var node = doc.DocumentNode.SelectNodes();




            //HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();
            //foreach (HtmlNode item in nodes)
            //{
            //    Console.WriteLine(item.InnerHtml);
            //}
            ////var webGet = new HtmlWeb();
            ////var doc = webGet.LoadFromWebAsync("http://www.cpp.edu/");

            ////HtmlNode ourNode = doc.DocumentNode.SelectSingleNode

        }






    }
}
