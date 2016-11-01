using ClassTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public class ProcessCSForCourseScheduleItems
    {
        //public CurriculumSheet _cs;

        //public ProcessCSForCourseScheduleItems(CurriculumSheet cs)
        //{
        //     _cs = cs;
        //}

        public async void Process(CurriculumSheet cs)
        {
            CurriculumSheet newCS = new CurriculumSheet();



            foreach(var c in cs.Modules)
            {

                if(c.Items != null)
                {
                    foreach (CourseItem cc in c.Items)
                    {

                        GETCourseFromPublicSchedule get = new GETCourseFromPublicSchedule();

                        var items = await get.GetAvailableCourse(cc.Number);

                        cc.CourseScheduleItems = items;
                    }

                }

            }
        }

    }
}
