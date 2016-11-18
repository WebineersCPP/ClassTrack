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
        /// <summary>
        /// Retrieves a particular curriculum sheet from a given user
        /// </summary>
        /// <param name="username">The owner of the curriculum sheet</param>
        /// <param name="id">The id of the specific curriculum sheet</param>
        /// <returns></returns>
        CurriculumSheet GetCurriculumSheet(string username, int id);

        /// <summary>
        /// Retrieves all the curriculum sheets pertaining to a particular user
        /// </summary>
        /// <param name="username">The owner of the curriculum sheets to be retrieved</param>
        /// <returns></returns>
        IEnumerable<CurriculumSheet> GetAllCurriculumSheets(string username);

        /// <summary>
        /// Updates a specific item's highlight color
        /// </summary>
        /// <param name="itemId">The specific item id to be updated</param>
        /// <param name="hcolor">The highlight color key to be applied to the item</param>
        Item UpdateItemHighlightColor(int itemId, short hcolor);

        /// <summary>
        /// Retrieves all majors available from CPP
        /// </summary>
        /// <returns></returns>
        IEnumerable<CPPMajor> GetAllCPPMajors();

    }
}
