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

namespace LifeLine.Infrastructure
{
   public class BloodDonorRepository : IBloodDonorRepository
    {

        BloodDonorContext context = new BloodDonorContext();

        public string UserName { get; set; }

        public void Add(BloodDonorModel b)
        {
            context.BloodDonors.Add(b);
            context.SaveChanges(UserName);
        }

        public void Edit(BloodDonorModel b)
        {
            //context.Entry(b).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges(UserName);
        }

        public void Remove(int BloodDonorID)
        {
            BloodDonorModel b = context.BloodDonors.Find(BloodDonorID);
            context.BloodDonors.Remove(b);
            context.SaveChanges(UserName);
        }

        public IEnumerable<BloodDonorModel> GetBloodDonors()
        {            
            return context.BloodDonors;
        }

        public BloodDonorModel FindById(int BloodDonorID)
        {           
            var bloodDonor = (from r in context.BloodDonors where r.ID == BloodDonorID select r).FirstOrDefault();
            return bloodDonor; 
        }

        public DbSet<AuditLog> AuditLog()
        {
            return context.AuditLog;
        }
        
    }
}
