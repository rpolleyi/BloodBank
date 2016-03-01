using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        void Edit(T entity);
        T FindById(Guid id);

        IQueryable<AuditLog> AuditLog();

    }
}
