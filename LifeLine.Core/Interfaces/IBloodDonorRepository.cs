using LifeLine.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Interfaces
{
    /// <summary>
    /// Blood donor reporsitory interface for DB CRUD/Audit log
    /// </summary>
    public interface IBloodDonorRepository   
    {
        string UserName { get; set; }

        void Add(BloodDonorModel b);
        void Edit(BloodDonorModel b);
        void Remove(int BloodDonorID);
        IEnumerable<BloodDonorModel> GetBloodDonors();
        BloodDonorModel FindById(int BloodDonorID);
        DbSet<AuditLog> AuditLog();
    }
}
