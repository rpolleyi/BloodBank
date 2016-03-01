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
using System;

namespace LifeLine.Infrastructure
{
    /// <summary>
    /// Implementation for IDonationRepository
    /// </summary>
    public class DonationRepository : IDonationRepository
    {
        BloodDonorContext context = new BloodDonorContext();

        public string UserName { get; set; }

        /// <summary>
        /// Adding a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Add(Person p)
        {
            context.Persons.Add(p);
            context.SaveChanges(UserName);
        }

        /// <summary>
        /// Updates a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Edit(Person p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges(UserName);
        }

        /// <summary>
        /// Removes a donor/recipient to the DB
        /// </summary>
        /// <param name="p">details of the donor/recipient</param>
        public void Remove(int? Id)
        {
            Person p = context.Persons.Find(Id);
            context.Persons.Remove(p);
            context.SaveChanges(UserName);
        }

        /// <summary>
        /// Find a donor/recipient by Id from the DB
        /// </summary>
        /// <param name="Id">Id of the donor/recipient</param>
        public Person FindById(int? Id)
        {
            var person = (from r in context.Persons where r.Id == Id select r).FirstOrDefault();
            return person;
        }

        /// <summary>
        /// Retrievs all Persons i.e. donor/recipient from the DB
        /// </summary>
        public IEnumerable<Person> GetPersons()
        {
            return context.Persons;
        }

        /// <summary>
        /// All the auditlog related to donor/recipient
        /// </summary>
        /// <returns></returns>
        public DbSet<AuditLog> AuditLog()
        {
            return context.AuditLog;
        }        
    }
}
