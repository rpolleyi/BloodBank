using LifeLine.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Web.ViewModel
{
    /// <summary>
    /// Details about Donor(derived from Person class TPH approach)
    /// </summary>
    [TrackChanges]
    public class DonorViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Donor First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Donor Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Donation On")]
        [DataType(DataType.Date)]
        public string DonationDate { get; set; }
        
        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }

    }
}
