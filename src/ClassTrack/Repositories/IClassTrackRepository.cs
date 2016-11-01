using ClassTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Repositories
{
    public interface IClassTrackRepository
    {
        CurriculumSheet GetCurriculumSheet(string username, int id);

        CurriculumSheet GetCurriculumSheet(string username, int year, string major, string subplan);

        IEnumerable<CurriculumSheet> GetAllCurriculumSheets(string username);

        void AddCurriculumSheet(CurriculumSheet curriculumSheet);

        Task<bool> SaveChangesAsync();
    }
}
