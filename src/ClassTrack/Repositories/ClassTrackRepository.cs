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
                CurriculumSheet sheet = _context.CurriculumSheets
                           .Where(cs => cs.UserName == username && cs.Id == id && cs.IsActive == true)
                           .Include(cs => cs.Modules)
                           .ThenInclude(m => m.Items)
                           .FirstOrDefault();

                // Sort items by numId
                foreach (var m in sheet.Modules)
                {
                    List<Item> list = m.Items.OrderBy(i => i.NumId).ToList();
                    m.Items = list;
                }
                return sheet;
            }
            return null;
        }

        public IEnumerable<CurriculumSheet> GetAllActiveCurriculumSheets(string username)
        {
            return _context.CurriculumSheets
                           .Where(cs => cs.UserName == username && cs.IsActive == true)
                           .ToList();
        }

        public void DeleteCurriculumSheet(string username, int id)
        {
            CurriculumSheet csToDelete = _context.CurriculumSheets
                          .Where(cs => cs.UserName == username && cs.Id == id)
                          .FirstOrDefault();

            if (csToDelete != null)
            {
                if (csToDelete.IsActive != false)
                {
                    csToDelete.IsActive = false;
                    _context.SaveChanges();
                }
            }
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
