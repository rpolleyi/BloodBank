using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Interfaces;
using LifeLine.Core.Models;
using LifeLine.Web.ViewModel;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Test.Service
{
    public class FakeDonorRepository : IDonationRepository
    {
        public void Add(Donor entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AuditLog> AuditLog()
        {
            throw new NotImplementedException();
        }

        public void Edit(Donor entity)
        {
            throw new NotImplementedException();
        }

        public Donor FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Donor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Donor entity)
        {
            throw new NotImplementedException();
        }
    }
}
