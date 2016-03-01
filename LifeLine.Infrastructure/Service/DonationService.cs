using LifeLine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Models;
using TrackerEnabledDbContext.Common.Models;
using log4net;

namespace LifeLine.Infrastructure.Service
{
    public class DonationService : IDonationService
    {
        #region Private Members
        private readonly IDonationRepository _donationRepository;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DonationService));
        #endregion

        #region Constructor
        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        #endregion

        #region Public Methods

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
            _donationRepository.Add(p);
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
            _donationRepository.Edit(p);
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
            _donationRepository.Remove(p);
        }

        /// <summary>
        /// Retrievs all Persons i.e. donor/recipient from the DB
        /// </summary>
        public IEnumerable<Donor> GetAll()
        {
            return _donationRepository.GetAll();
        }

        /// <summary>
        /// Find a donor/recipient by Id from the DB
        /// </summary>
        /// <param name="id">Id of the donor/recipient</param>
        public Donor FindById(Guid id)
        {
            return _donationRepository.FindById(id);
        }

        /// <summary>
        /// All the auditlog related to donor/recipient
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AuditLog> AuditLog()
        {
            return _donationRepository.AuditLog();
        }

        #endregion
    }
}
