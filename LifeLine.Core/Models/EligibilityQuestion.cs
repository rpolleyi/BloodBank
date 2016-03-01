using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeLine.Core.Models
{
    public class EligibilityQuestion
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<EligibilityOption> Options { get; set; }
    }
}
