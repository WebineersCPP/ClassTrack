using ClassTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Repositories
{
    public class ClassTrackRepository : IClassTrackRepository
    {
        private ClassTrackContext _context;

        public ClassTrackRepository(ClassTrackContext context)
        {
            _context = context;
        }

        public CurriculumSheet GetCurriculumSheet(string username, int id)
        {
            if (username != null)   
            {
                return _context.CurriculumSheets
                           .Where(cs => cs.UserName == username && cs.Id == id)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .FirstOrDefault();
            }
            return null;
        }

        public CurriculumSheet GetCurriculumSheet(string username, int year, string major, string subplan)
        {
            if (username != null && major != null) // and year is not null
                                                   // queryin an empty subplan is ok? is it possible to set default val of subplan catalog?
            {
                return _context.CurriculumSheets
                           .Where(cs => cs.UserName == username && cs.Major == major && cs.Subplan == subplan && cs.Year == year)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<CurriculumSheet> GetAllCurriculumSheets(string username)
        {
            return _context.CurriculumSheets
                           .Where(cs => cs.UserName == username)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .ToList();
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
