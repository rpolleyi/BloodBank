using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    /// <summary>
    /// the output/status after blood donation
    /// </summary>
    public enum Status
    {
        Success, Failure, ComplexityFound
    }

    /// <summary>
    /// details for the donation regarding Donor, recipient and result of donation
    /// </summary>
    public class Donation
    {
        public int DonationId { get; set; }
        [Display(Name = "Donor")]
        public int DonorId { get; set; }

        [Display(Name = "Recipient")]
        public int? RecipientId { get; set; }

        [Display(Name = "Status")]
        public Status? Result { get; set; }
        public virtual Donor Donor { get; set; }
        
        public virtual Recipient Recipient { get; set; }

    }
}
