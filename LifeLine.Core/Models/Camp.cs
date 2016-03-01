using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    public class Camp
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Utilities.Constants.CampContants.CAMP_NAME_LENGTH)]
        public string Name { get; set; }

        [Required]
        [StringLength(Utilities.Constants.CampContants.WHERE_LENGTH)]
        public string Where { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string When { get; set; }
        
        [NotMapped]
        public virtual List<Donor> Donors { get; set; }
    }
}
