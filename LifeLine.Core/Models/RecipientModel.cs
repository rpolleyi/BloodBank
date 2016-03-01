using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    public class RecipientModel : PersonModel
    {
        public string PhoneNumber { get; set; }

        public string Age { get; set; }

        public ICollection<BloodDonorModel> BloodDonors { get; set; }
    }
}
