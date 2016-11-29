using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public interface IFetchCatalogURLService
    {
        String GetMajorPlanUrl(int year, string major, string subplan = null);
    }
}
