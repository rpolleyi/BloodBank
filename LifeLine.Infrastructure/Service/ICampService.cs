using LifeLine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Models;
using TrackerEnabledDbContext.Common.Models;
using System.Web.Mvc;

namespace LifeLine.Infrastructure.Service
{
    public interface ICampService
    {
        /// <summary>
        /// Adding a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        void Add(Camp c);

        /// <summary>
        /// Updates a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        void Edit(Camp c);

        /// <summary>
        /// Removes a camp entry to the DB
        /// </summary>
        /// <param name="c">details of the camp entry</param>
        void Remove(Camp c);

        /// <summary>
        /// Retrievs all Persons i.e. camp entry from the DB
        /// </summary>
        IEnumerable<Camp> GetAll();

        /// <summary>
        /// Find a camp entry by Id from the DB
        /// </summary>
        /// <param name="id">Id of the camp entry</param>
        Camp FindById(Guid id);

        SelectList GetCampsList();
    }
}
