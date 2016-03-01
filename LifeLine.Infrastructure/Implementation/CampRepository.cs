using System.Collections.Generic;
using System.Linq;
using LifeLine.Core;
using LifeLine.Core.Interfaces;
using TrackerEnabledDbContext.Common.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data;
using LifeLine.Core.Models;
using System;
using System.Threading;
using log4net;

namespace LifeLine.Infrastructure.Implementation
{
    /// <summary>
    /// Implementation for ICampRepository
    /// </summary>
    public class CampRepository : ICampRepository
    {
        #region Private Members
        private readonly BloodDonorContext _context = new BloodDonorContext();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CampRepository));
        #endregion

        #region Donor
        /// <summary>
        /// Adding a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        public void Add(Camp c)
        {
            if (c == null)
            {
                _logger.ErrorFormat("Invalid Camp");
                throw new ArgumentNullException(nameof(c));
            }
            _context.Camps.Add(c);
            _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
        }
        /// <summary>
        /// Removes a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        public void Remove(Camp c)
        {
            if (c == null)
            {
                _logger.ErrorFormat("Invalid Camp");
                throw new ArgumentNullException(nameof(c));
            }

            _context.Camps.Remove(c);
            _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
        }
        /// <summary>
        /// Retrievs all Camps i.e. camp entry from the DB
        /// </summary>
        public IQueryable<Camp> GetAll()
        {
            return _context.Camps;
        }
        /// <summary>
        /// Updates a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        public void Edit(Camp c)
        {
            if (c == null)
            {
                _logger.ErrorFormat("Invalid Camp");
                throw new ArgumentNullException(nameof(c));
            }

            if (!_context.Camps.Any(x => x.Id == c.Id))
            {
                _logger.ErrorFormat($"Cannot find Todo item with id {c.Id}");
                throw new DonorNotFoundException($"Cannot find Todo item with id {c.Id}");
            }
            else
            {
                _context.Entry(c).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
            }
        }

        /// <summary>
        /// Find a camp entry by Id from the DB
        /// </summary>
        /// <param name="Id">Id of the camp entry</param>
        public Camp FindById(Guid Id)
        {
            return (from r in _context.Camps where r.Id == Id select r).FirstOrDefault();            
        }

        /// <summary>
        /// All the auditlog related to camp entry
        /// </summary>
        /// <returns></returns>
        public IQueryable<AuditLog> AuditLog()
        {
            return _context.AuditLog;
        }
        #endregion
    }
}
