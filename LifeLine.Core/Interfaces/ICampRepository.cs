using LifeLine.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Interfaces
{
    /// <summary>
    /// Camp reporsitory interface for DB CRUD/Audit log
    /// </summary>
    public interface ICampRepository : IBaseRepository<Camp>
    {       
    }
}
