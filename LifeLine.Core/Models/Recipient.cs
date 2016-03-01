using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerEnabledDbContext.Common.Models;

namespace LifeLine.Core.Models
{
    /// <summary>
    /// Details about Recipient(derived from Person class TPH approach)
    /// </summary>
    [TrackChanges]
    public class Recipient : Person
    {
        [Display(Name = "Received On")]
        public string ReceivedDate { get; set; }
        
        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }

    }
}
