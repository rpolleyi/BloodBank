using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LifeLine.Core.Models
{
    public class EligibilityOption
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(Order = 0), ForeignKey("EligibilityQuestion")]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual EligibilityQuestion EligibilityQuestion { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}
