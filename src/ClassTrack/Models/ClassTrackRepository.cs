using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.CurriculumSheets.ToList();
        }

        public CurriculumSheet GetCurriculumSheet(string major, int year)
        {
            return _context.CurriculumSheets
                           .Include(cs => cs.Modules)
                           .Where(cs => cs.Major == major && cs.Year == year)
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
