using System.Data.Entity;
using LifeLine.Core;
using TrackerEnabledDbContext.Identity;
using TrackerEnabledDbContext.Common.Configuration;
using LifeLine.Core.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LifeLine.Infrastructure
{
    /// <summary>
    /// DB context for the application
    /// </summary>
   public class BloodDonorContext : TrackerIdentityContext<ApplicationUser>
    {
       public BloodDonorContext()
           : base("name=BloodDonorContext")
        {
           GlobalTrackingConfig.DisconnectedContext = true;
        }

        public static BloodDonorContext Create()
        {
            return new BloodDonorContext();
        }
        
        public DbSet<Donor> Persons { get; set; }

        public DbSet<Camp> Camps { get; set; }

        public DbSet<EligibilityQuestion> EligibilityQuestions { get; set; }

        public DbSet<EligibilityOption> EligibilityOptions { get; set; }

        public DbSet<EligibilityAnswer> EligibilityAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Donor>()
                .HasRequired(p => p.Camp).WithMany(c=>c.Donors);

            base.OnModelCreating(modelBuilder);
        }

    }
}
