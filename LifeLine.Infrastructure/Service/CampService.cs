using LifeLine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Models;
using TrackerEnabledDbContext.Common.Models;
using System.Web.Mvc;
using log4net;

namespace LifeLine.Infrastructure.Service
{
    public class CampService : ICampService
    {
        #region Private Members
        private readonly ICampRepository _campRepository;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CampService));
        #endregion

        #region Constructor
        public CampService(ICampRepository campRepository)
        {
            _campRepository = campRepository;
        }
        #endregion

        #region Public Methods

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
            _campRepository.Add(c);
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
            _campRepository.Edit(c);
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
            _campRepository.Remove(c);
        }

        /// <summary>
        /// Retrievs all Persons i.e. camp entry from the DB
        /// </summary>
        public IEnumerable<Camp> GetAll()
        {
            return _campRepository.GetAll();
        }

        /// <summary>
        /// Find a camp entry by Id from the DB
        /// </summary>
        /// <param name="id">Id of the camp entry</param>
        public Camp FindById(Guid id)
        {
            return _campRepository.FindById(id);
        }

        public SelectList GetCampsList()
        {
            return new SelectList(GetAll(), "Id", "Name");
        }
        #endregion
    }
}
