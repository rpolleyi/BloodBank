using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    public class PersonModel
    {
        [Required]        
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }
    }
}
