using BEApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEApi.Repositories
{
    public interface ISafeAuto
    {
        /// <summary>
        /// Return all the SafeAutos to exist in the database
        /// </summary>
        /// <returns>IEnumerable to <see cref="Models.SafeAuto"/></returns>
        Task<IEnumerable<Models.SafeAuto>> GetAllSafeAutos();

        /// <summary>
        /// Return all the InformationSafeAuto to exist in the database
        /// </summary>
        /// <returns>IEnumerable to <see cref="InformationSafeAuto"/></returns>
        Task<IEnumerable<InformationSafeAuto>> GetAllInformationSafeAutos();
        /// <summary>
        /// Save and especific <see cref="Models.SafeAuto"/> in Database
        /// </summary>
        /// <param Models.SafeAuto="safeAuto"></param>
        /// <returns>Task to int</returns>
        Task<int> PostSafeAuto(Models.SafeAuto safeAuto);
        /// <summary>
        /// Save and especific <see cref="InformationSafeAuto"/> in Database
        /// </summary>
        /// <param InformationSafeAuto="informationSafeAuto"></param>
        /// <returns>Task to int</returns>
        Task<int> PostSafeAutoInformation(InformationSafeAuto informationSafeAuto);
     
    }
}

