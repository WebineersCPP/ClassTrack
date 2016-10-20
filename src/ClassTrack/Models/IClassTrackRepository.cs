using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public interface IClassTrackRepository
    {
        IEnumerable<CurriculumSheet> GetAllCurriculumSheets();

        CurriculumSheet GetCurriculumSheet(string major, int year);

        void AddCurriculumSheet(CurriculumSheet curriculumSheet);

        Task<bool> SaveChangesAsync();
    }
}
