using LifeLine.Core.Models;
using LifeLine.Infrastructure.Service;
using LifeLine.Web.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Web.ViewModel
{
    /// <summary>
    /// Details about Donor(derived from Person class TPH approach)
    /// </summary>
    public class DonorVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Utilities.Constants.DonorContants.FIRST_NAME_LENGTH)]
        [Display(Name = Utilities.Constants.DonorContants.FIRST_NAME_DISPLAYNAME)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Utilities.Constants.DonorContants.LAST_NAME_LENGTH)]
        [Display(Name = Utilities.Constants.DonorContants.LAST_NAME_DISPLAYNAME)]
        public string LastName { get; set; }

        [Display(Name = Utilities.Constants.DonorContants.PHONE_DISPLAYNAME)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public Guid CampId { get; set; }

        [Required]
        [Display(Name = Utilities.Constants.DonorContants.CAMP_DISPLAYNAME)]
       // [NotMapped]
        public virtual Camp Camp { get; set; }

        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }

        [NotMapped]
        public SelectList CampsList
        {
            get; set;
        }   

    }
}
