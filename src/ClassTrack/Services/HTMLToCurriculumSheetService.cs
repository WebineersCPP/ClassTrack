using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ClassTrack.Models;

using System.Text.RegularExpressions;

namespace ClassTrack.Services
{
    public class HTMLToCurriculumSheetService : IHTMLToCurriculumSheetService
    {
        List<Item> courseItemList = new List<Item>();

        Stack<Module> tempModules = new Stack<Module>();
        Stack<Module> modules = new Stack<Module>();

        List<Module> modulesList = new List<Module>();
        CurriculumSheet cs = new CurriculumSheet();

        List<Item> courseList;
        bool listOpen = false;

        public string catalogLink { get; set; }
        //public IEnumerable<HtmlNode> loadedNodes { get; set; }

        List<int> descripLineLocation = new List<int>();
        List<int> nonCourseItemLocation = new List<int>();


        public async Task<CurriculumSheet> getCurriculumSheet(string url)
        {
            catalogLink = url;

            // Set up HtmlAgilityPack to fetch html data
            HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument html;

            try
            {
                html = await new HtmlWeb().LoadFromWebAsync(catalogLink);
            }
            catch (Exception e)
            {
                throw new Exception("Error loading url");
            }


            var root = html.DocumentNode;
            var htmlNodes = root.Descendants();


            // Set catalog year to the curriculum sheet
            var ano = root.Descendants().Where(p => p.GetAttributeValue("name", "").Equals("catalog"));

            String yearStr = "";
            foreach (HtmlNode node in ano)
                yearStr = node.InnerHtml;

            int yearInt;
            Int32.TryParse(yearStr.Substring(yearStr.IndexOf("selected") + 12, 4), out yearInt);
            cs.Year = yearInt;



            // Initialize and find description locations
            var descrip = root.Descendants().Where(p => p.GetAttributeValue("class", "").Equals("acalog-core"));

            foreach (HtmlNode node in descrip)
            {
                foreach (HtmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name == "p" && !cnode.InnerHtml.Contains("<strong>"))
                        descripLineLocation.Add(cnode.LinePosition);

                    if (cnode.Name == "p" && !cnode.InnerHtml.Contains("<strong>"))
                        descripLineLocation.Add(cnode.LinePosition);

                    if (cnode.Name == "ul" && !cnode.InnerHtml.Contains("<strong>") && !cnode.InnerHtml.Contains("\"acalog-course\""))
                        nonCourseItemLocation.Add(cnode.LinePosition);


                }
            }



            //loadedNodes = htmlNodes;

            foreach (HtmlNode node in htmlNodes)
            {
                if (node.Name == "h1")
                {
                    if (node.InnerText.Contains("Subplan"))
                    {
                        String title = node.InnerText;

                        String fromStr = " - ";
                        String toStr = "Subplan";
                        int pFrom = title.IndexOf(fromStr) + fromStr.Length;
                        int pTo = title.LastIndexOf(toStr);

                        String major = title.Substring(0, title.IndexOf(fromStr));
                        String subplan = title.Substring(pFrom, pTo - pFrom);

                        cs.Major = major;
                        cs.Subplan = subplan;
                        break;
                    }
                    else
                    {
                        cs.Major = node.InnerText;
                        break;
                    }
                }
            }

            // Search through fetched html nodes for relevant information
            foreach (HtmlNode node in htmlNodes)
            {
                Module currentModule;

                // Module with h2 tag
                if (node.Name == "h2")
                {
                    if (listOpen == true)
                    {
                        tempModules.Peek().Items = courseList;
                        listOpen = false;
                    }

                    currentModule = new Module();
                    currentModule.Title = node.InnerText;



                    String unitStr = Regex.Match(node.InnerText, @"\d+").Value;
                    int unitInt;
                    Int32.TryParse(unitStr, out unitInt);

                    currentModule.Units = unitInt;
                    currentModule.IsSubmodule = false;

                    tempModules.Push(currentModule);
                }

                // Submodule with h3 tag
                if (node.Name == "h3")
                {
                    if (listOpen == true)
                    {
                        tempModules.Peek().Items = courseList;
                        listOpen = false;
                    }

                    currentModule = new Module();
                    currentModule.Title = node.InnerText;
                    currentModule.IsSubmodule = true;

                    tempModules.Push(currentModule);
                }

                // Get description for module
                foreach (int i in descripLineLocation)
                {
                    if (i == node.LinePosition && tempModules.Count != 0)
                    {
                        tempModules.Peek().Description = node.InnerText.Replace("&#160;", " ");
                        break;
                    }
                }




                // Courses with acalog-course class attribute
                if (node.GetAttributeValue("class", "").Equals("acalog-course"))
                {
                    // New course list in new module/submodule
                    if (listOpen == false)
                    {
                        courseList = new List<Item>();
                        listOpen = true;
                    }

                    Item course = new Item();
                    course.IsCourse = true;

                    // Markers to retrieve course title & course number in Course text 
                    int titleStartIndex = 0;
                    int titleEndIndex = 0;
                    int numberEndIndex = 0;

                    string courseText = node.InnerText;

                    // Scan Course text for relavent patterns
                    for (int i = 0; i < courseText.Length - 3; i++)
                    {
                        if (courseText.Substring(i, 3).Equals(" - "))
                        {
                            numberEndIndex = i;
                            titleStartIndex = i + 3;
                            break;
                        }
                    }
                    for (int i = 0; i < courseText.Length - 1; i++)
                    {
                        if (courseText.Substring(i, 1).Equals("("))
                        {
                            titleEndIndex = i - 1;
                            break;
                        }
                    }

                    // Account for possible course units scenarios
                    if (courseText.Contains("(1)"))
                        course.Units = 1;
                    else if (courseText.Contains("(2)"))
                        course.Units = 2;
                    else if (courseText.Contains("(3)"))
                        course.Units = 3;
                    else if (courseText.Contains("(4)"))
                        course.Units = 4;
                    else if (courseText.Contains("1-2"))
                        course.Units = 2;
                    else if (courseText.Contains("1-3"))
                        course.Units = 3;
                    else if (courseText.Contains("1-4"))
                        course.Units = 4;
                    else
                        course.Units = 4;

                    // Assign retrieved course into
                    course.Number = courseText.Substring(0, numberEndIndex);
                    course.Title = courseText.Substring(titleStartIndex, titleEndIndex - titleStartIndex);

                    courseList.Add(course);
                }
                else if (node.GetAttributeValue("class", "").StartsWith("acalog-adhoc"))
                {
                    if (listOpen == false)
                    {
                        courseList = new List<Item>();
                        listOpen = true;
                    }

                    Item course = new Item();
                    course.IsCourse = false;

                    course.Title = node.InnerText.Trim();
                    if (course.Title != "&#160;")
                        courseList.Add(course);

                }
                else //if (node.Name == "ul" && node.InnerHtml.Contains("<strong>") == false)
                {
                    // Get description for module
                    foreach (int i in nonCourseItemLocation)
                    {
                        if (i == node.LinePosition)
                        {
                            if (listOpen == false)
                            {
                                courseList = new List<Item>();
                                listOpen = true;
                            }

                            Item course = new Item();
                            course.IsCourse = false;

                            course.Title = node.InnerText.Trim();

                            if(course.Title != "&#160;")
                                courseList.Add(course);
                            break;
                        }
                    }
                }
            }

            //for(Module m : tempModules)

            // Add GE Module
            GETGEModule getGE = new GETGEModule();
            Module realGE = getGE.ge;
            tempModules.Push(realGE);


            // Reverse temporary stack data structure
            while (tempModules.Count != 0)
            {
                if(tempModules.Peek().Title.Contains("General Education Requirements") && tempModules.Peek() != realGE)
                    tempModules.Pop();
                else
                    modules.Push(tempModules.Pop());
            }

            modulesList = modules.ToList();
            cs.Modules = modulesList;

            // Return curriculum sheet
            return cs;
        }

    }
}


