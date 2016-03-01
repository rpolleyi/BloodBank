using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LifeLine.Core.Models
{
    public class EligibilityAnswer
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public int OptionId { get; set; }
        
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual EligibilityOption EligibilityOption { get; set; }
    }
}
