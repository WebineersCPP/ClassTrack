using ClassTrack.Models;
using ClassTrack.Services;
using ClassTrack.ViewModels;
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

        public IEnumerable<CurriculumSheet> GetAllCurriculumSheets(string username)
        {
            return _context.CurriculumSheets
                           .Where(cs => cs.UserName == username)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .ToList();
        }

        public CurriculumSheet PostCurriculumSheet(CurriculumSheet cs)
        {
            try
            {
                _context.CurriculumSheets.Add(cs);
                _context.SaveChanges();

                return cs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Item UpdateItemHighlightColor(int itemId, short hcolor)
        {
            Item itemToUpdate = _context.Items
                                        .Where(i => i.Id == itemId)
                                        .FirstOrDefault();
            if (itemToUpdate != null)
            {
                itemToUpdate.HighlightColor = hcolor;
                _context.SaveChanges();

                return itemToUpdate;
            }

            return null;
        }

        public IEnumerable<CPPMajor> GetAllCPPMajors()
        {
            return _context.CPPMajors
                           .Include(m => m.Subplans)
                           .ToList();
        }
        
    }
}
