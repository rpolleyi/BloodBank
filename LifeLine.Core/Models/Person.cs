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
    /// Details about Person(Base class for Donor/Recipient)
    /// </summary>
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name ="First Name")]
        public string FirstName { get; set;}

        [Required]
        [StringLength(10)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
