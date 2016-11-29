using ClassTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public interface IHTMLToCurriculumSheetService
    {
        Task<CurriculumSheet> getCurriculumSheet(String url);
    }
}
