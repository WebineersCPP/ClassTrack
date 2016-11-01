using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using ClassTrack.Models;
using System.Net;
//using System.Web.Http;

namespace ClassTrack.Services
{
    public class HTMLToCurriculumSheetService
    {
        List<CourseItem> courseItemList = new List<CourseItem>();

        static Stack<Module> tempModules = new Stack<Module>();
        static Stack<Module> modules = new Stack<Module>();

        static List<Module> modulesList = new List<Module>();
        static CurriculumSheet cs = new CurriculumSheet();

        static List<Item> courseList;
        static bool listOpen = false;

        public string catalogLink { get; set; }
        //public IEnumerable<HtmlNode> loadedNodes { get; set; }


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

            //loadedNodes = htmlNodes;

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

                // Courses with acalog-course class attribute
                if (node.GetAttributeValue("class", "").Equals("acalog-course"))
                {
                    // New course list in new module/submodule
                    if (listOpen == false)
                    {
                        courseList = new List<Item>();
                        listOpen = true;
                    }

                    CourseItem course = new CourseItem();

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
            }

            // Reverse temporary stack data structure
            while (tempModules.Count != 0)
            {
                modules.Push(tempModules.Pop());
            }

            modulesList = modules.ToList();
            cs.Modules = modulesList;

            // Return curriculum sheet
            return cs;
        }
    }
}


