using BEApi.DBContext;
using BEApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEApi.Repositories
{
    public class SafeAuto : ISafeAuto
    {
        /// <summary>
        /// Inyect to the constructor the context <see cref="SafeAutoDBContext"/> and the transactions
        /// </summary>
        /// <param SafeAutoDBContext="context"></param>
        public SafeAuto(SafeAutoDBContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();

        }
        private readonly SafeAutoDBContext _context;
        private IDbContextTransaction _transaction;

        /// <summary>
        /// Return all the InformationSafeAuto to exist in the database
        /// </summary>
        /// <returns>IEnumerable to <see cref="InformationSafeAuto"/></returns>
        public async Task<IEnumerable<InformationSafeAuto>> GetAllInformationSafeAutos()
        {
            return await _context.InformationSafeAutos.ToListAsync();
        }

        /// <summary>
        /// Return all the SafeAutos to exist in the database
        /// </summary>
        /// <returns>IEnumerable to <see cref="Models.SafeAuto"/></returns>
        public async Task<IEnumerable<Models.SafeAuto>> GetAllSafeAutos()
        {
            return await _context.SafeAutos.ToListAsync();
        }

        /// <summary>
        /// Save and especific <see cref="Models.SafeAuto"/> in Database
        /// </summary>
        /// <param Models.SafeAuto="safeAuto"></param>
        /// <returns>Task to int</returns>
        public async Task<int> PostSafeAuto(Models.SafeAuto safeAuto)
        {
            int result = 0;
            var IsExist = _context.SafeAutos.Where(x => x.Name == safeAuto.Name).FirstOrDefault();
            if (IsExist is null)
            {
                try
                {
                    _context.SafeAutos.Add(safeAuto);
                    result = await _context.SaveChangesAsync();
                    _transaction.Commit();
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                }

            }
            return result;
        }

        /// <summary>
        /// Save and especific <see cref="InformationSafeAuto"/> in Database
        /// </summary>
        /// <param InformationSafeAuto="informationSafeAuto"></param>
        /// <returns>Task to int</returns>
        public async Task<int> PostSafeAutoInformation(InformationSafeAuto informationSafeAuto)
        {
            informationSafeAuto.SafeAutoId = _context.SafeAutos.Where(x => x.Name == informationSafeAuto.Name).Select(y => y.Id).FirstOrDefault();
            int result = 0;

            if (informationSafeAuto.SafeAutoId > 0)
            {
                try
                {
                    _context.InformationSafeAutos.Add(informationSafeAuto);
                    result = await _context.SaveChangesAsync();
                    _transaction.Commit();
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                }

            }
           return result;
        }
    }
}
