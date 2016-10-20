using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.ViewModels;

namespace ClassTrack.Models
{
    public class ClassTrackRepository : IClassTrackRepository
    {
        private ClassTrackContext _context;

        public ClassTrackRepository(ClassTrackContext context)
        {
            _context = context;
        }


        public IEnumerable<CurriculumSheet> GetAllCurriculumSheets()
        {
            return _context.CurriculumSheets
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .ToList();
        }

        public CurriculumSheet GetCurriculumSheet(int year, string major, string subplan)
        {
            return _context.CurriculumSheets
                           .Where(cs => cs.Major == major && cs.Subplan == subplan && cs.Year == year)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .FirstOrDefault();
        }

        public void AddCurriculumSheet(CurriculumSheet sheet)
        {
            if (sheet != null)
            {
                _context.CurriculumSheets.Add(sheet);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
