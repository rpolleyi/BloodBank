using LifeLine.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.ViewModel
{
    /// <summary>
    /// Details about Donor(derived from Person class TPH approach)
    /// </summary>
    [TrackChanges]
    public class RecipientViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Recipient First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Recipient Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Received On")]
        [DataType(DataType.Date)]
        public string ReceivedDate { get; set; }
        
        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }

    }
}
