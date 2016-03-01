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
    /// Implementation for IDonationRepository
    /// </summary>
    public class DonationRepository : IDonationRepository
    {
        #region Private Members
        private readonly BloodDonorContext _context = new BloodDonorContext();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DonationRepository));
        #endregion

        #region Donor
        /// <summary>
        /// Adding a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Add(Donor p)
        {
            if (p == null)
            {
                _logger.ErrorFormat("Invalid Donor");
                throw new ArgumentNullException(nameof(p));
            }
            _context.Persons.Add(p);
            _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
        }
        /// <summary>
        /// Removes a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Remove(Donor p)
        {
            if (p == null)
            {
                _logger.ErrorFormat("Invalid Donor");
                throw new ArgumentNullException(nameof(p));
            }

            _context.Persons.Remove(p);
            _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
        }
        /// <summary>
        /// Retrievs all Persons i.e. donor/recipient from the DB
        /// </summary>
        public IQueryable<Donor> GetAll()
        {
            return _context.Persons;
        }
        /// <summary>
        /// Updates a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Edit(Donor p)
        {
            if (p == null)
            {
                _logger.ErrorFormat("Invalid Donor");
                throw new ArgumentNullException(nameof(p));
            }

            if (!_context.Persons.Any(x => x.Id == p.Id))
            {
                _logger.ErrorFormat($"Cannot find Donor with id {p.Id}");
                throw new DonorNotFoundException($"Cannot find Donor with id {p.Id}");
            }
            else
            {
                _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges(Thread.CurrentPrincipal.Identity.Name);
            }
        }

        /// <summary>
        /// Find a donor/recipient by Id from the DB
        /// </summary>
        /// <param name="Id">Id of the donor/recipient</param>
        public Donor FindById(Guid Id)
        {
            return (from r in _context.Persons where r.Id == Id select r).FirstOrDefault();            
        }

        /// <summary>
        /// All the auditlog related to donor/recipient
        /// </summary>
        /// <returns></returns>
        public IQueryable<AuditLog> AuditLog()
        {
            return _context.AuditLog;
        }
        #endregion
    }
}
