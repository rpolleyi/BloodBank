using LifeLine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Infrastructure.Service
{
    public interface IDonationService
    {
        /// <summary>
        /// Adding a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        void Add(Donor p);

        /// <summary>
        /// Updates a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        void Edit(Donor p);

        /// <summary>
        /// Removes a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        void Remove(Donor p);

        /// <summary>
        /// Retrievs all Persons i.e. donor/recipient from the DB
        /// </summary>
        IEnumerable<Donor> GetAll();
        /// <summary>
        /// Find a donor/recipient by Id from the DB
        /// </summary>
        /// <param name="id">Id of the donor/recipient</param>
        Donor FindById(Guid id);

        /// <summary>
        /// All the auditlog related to donor/recipient
        /// </summary>
        /// <returns></returns>
        IEnumerable<AuditLog> AuditLog();
    }
}
