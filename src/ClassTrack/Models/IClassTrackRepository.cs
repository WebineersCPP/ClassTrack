﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.ViewModels;

namespace ClassTrack.Models
{
    public interface IClassTrackRepository
    {
        IEnumerable<CurriculumSheet> GetAllCurriculumSheets();

        CurriculumSheet GetCurriculumSheet(int year, string major, string subplan);

        void AddCurriculumSheet(CurriculumSheet curriculumSheet);

        Task<bool> SaveChangesAsync();
    }
}