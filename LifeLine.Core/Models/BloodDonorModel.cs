using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Models
{
    [TrackChanges]
    public class BloodDonorModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public string City { get; set; }

        public string Country { get; set; }
        [Required]
        public int PinCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        //[NotMapped]
        //public virtual List<AuditLog> AuditLogs { get; set; }


    }
}
