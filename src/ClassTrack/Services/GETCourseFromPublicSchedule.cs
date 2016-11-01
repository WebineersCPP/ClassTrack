using ClassTrack.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public class GETCourseFromPublicSchedule
    {
        ICollection<CourseScheduleItem> list = new List<CourseScheduleItem>();

        public async Task<ICollection<CourseScheduleItem>> GetAvailableCourse(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync("http://broncoscheduler.com/request.php?fall2015&class=" + id);

                dynamic parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(json.Result);


                foreach (Newtonsoft.Json.Linq.JObject c in parsedJson)
                {
                    CourseScheduleItem item = new CourseScheduleItem();

                    foreach (var cc in c)
                    {
                        if (cc.Key == "classSubject")
                            item.Number = cc.Value.ToString();
                        if (cc.Key == "catNumber")
                            item.Number += cc.Value.ToString();
                        if (cc.Key == "classSection")
                            item.Section = Int32.Parse(cc.Value.ToString());
                        if (cc.Key == "title")
                            item.Title = cc.Value.ToString();
                        if (cc.Key == "units")
                            item.Units = Int32.Parse(cc.Value.ToString());
                        if (cc.Key == "classTimeStart")
                            item.StartTime = Int32.Parse(cc.Value.ToString());
                        if (cc.Key == "classTimeEnd")
                            item.EndTime = Int32.Parse(cc.Value.ToString());

                        string StartTime, EndTime;
                        if ((item.StartTime % 100) < 10)
                            StartTime = ((item.StartTime / 100) % 12) + ":0" + item.StartTime % 100;
                        else
                            StartTime = ((item.StartTime / 100) % 12) + ":" + item.StartTime % 100;
                        if (item.StartTime < 1200)
                            StartTime += "AM";
                        else
                            StartTime += "PM";

                        if ((item.EndTime % 100) < 10)
                            EndTime = ((item.EndTime / 100) % 12) + ":0" + item.EndTime % 100;
                        else
                            EndTime = ((item.EndTime / 100) % 12) + ":" + item.EndTime % 100;
                        if (item.EndTime < 1200)
                            EndTime += "AM";
                        else
                            EndTime += "PM";

                        item.Time = StartTime + " - " + EndTime;

                        if (cc.Key == "classDays")
                        {
                            switch (Int32.Parse(cc.Value.ToString()))
                            {
                                case 5:
                                    item.Days = "MoWe";
                                    break;
                                case 10:
                                    item.Days = "TuTh";
                                    break;
                                case 21:
                                    item.Days = "MoWeFr";
                                    break;
                                case 1:
                                    item.Days = "Mo";
                                    break;
                                case 2:
                                    item.Days = "Tu";
                                    break;
                                case 3:
                                    item.Days = "Mo";
                                    break;
                                case 4:
                                    item.Days = "Th";
                                    break;
                                case 16:
                                    item.Days = "Fr";
                                    break;
                                case 32:
                                    item.Days = "Sa";
                                    break;
                            }
                        }
                        if (cc.Key == "room")
                            item.Room = cc.Value.ToString();
                        if (cc.Key == "instructor")
                            item.Instructor = cc.Value.ToString();
                        if (cc.Key == "classNbr")
                            item.ClassNumber = Int32.Parse(cc.Value.ToString());
                    }

                    list.Add(item);

                }       // end foreach

                 return list;

            }   // end using
        }       // end method
    }           // end class
}
