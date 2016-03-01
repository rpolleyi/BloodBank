using System.Data.Entity;
using LifeLine.Core;
using TrackerEnabledDbContext.Identity;
using TrackerEnabledDbContext.Common.Configuration;
using LifeLine.Core.Models;

namespace LifeLine.Infrastructure
{
    public class EligibilityContext : DbContext
    {
        public EligibilityContext()
           : base("name=BloodDonorContext")
        {
            //var a = Database.Connection.ConnectionString;
            GlobalTrackingConfig.DisconnectedContext = true;
        }

        public static EligibilityContext Create()
        {
            return new EligibilityContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<EligibilityOption>()
                .HasKey(o => new { o.QuestionId, o.Id });

            builder.Entity<EligibilityAnswer>()
                .HasRequired(a => a.EligibilityOption)
                .WithMany()
                .HasForeignKey(a => new { a.QuestionId, a.OptionId });

            builder.Entity<EligibilityQuestion>()
                .HasMany(q => q.Options)
                .WithRequired();// o => o.EligibilityQuestion);
        }

        public DbSet<EligibilityQuestion> EligibilityQuestions { get; set; }

        public DbSet<EligibilityOption> EligibilityOptions { get; set; }

        public DbSet<EligibilityAnswer> EligibilityAnswers { get; set; }
    }
}
