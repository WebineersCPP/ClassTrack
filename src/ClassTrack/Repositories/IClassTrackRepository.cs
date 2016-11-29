using ClassTrack.Models;
using ClassTrack.ViewModels;
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
        /// Retrieves a particular curriculum sheet from a given user. Active only.
        /// </summary>
        /// <param name="username">The owner of the curriculum sheet</param>
        /// <param name="id">The id of the specific curriculum sheet</param>
        /// <returns></returns>
        CurriculumSheet GetCurriculumSheet(string username, int id);

        /// <summary>
        /// Retrieves all active curriculum sheets pertaining to a particular user
        /// </summary>
        /// <param name="username">The owner of the curriculum sheets to be retrieved</param>
        /// <returns></returns>
        IEnumerable<CurriculumSheet> GetAllActiveCurriculumSheets(string username);

        /// <summary>
        /// Adds a new user curriculum sheet to the database
        /// </summary>
        /// <param name="cs">The curriculum sheet to be added</param>
        /// <returns></returns>
        CurriculumSheet PostCurriculumSheet(CurriculumSheet cs);

        /// <summary>
        /// Makes a given curriculum sheet inactive
        /// </summary>
        /// <param name="username">The owner of the curriculum sheet</param>
        /// <param name="id">The id of the specific curriculum sheet</param>
        void DeleteCurriculumSheet(string username, int id);

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
