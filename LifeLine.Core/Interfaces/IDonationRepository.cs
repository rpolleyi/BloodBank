using LifeLine.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Interfaces
{
    /// <summary>
    /// Donation reporsitory interface for DB CRUD/Audit log
    /// </summary>
    public interface IDonationRepository : IBaseRepository<Donor>
    {       
    }
}
