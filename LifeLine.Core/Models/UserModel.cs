using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    /// <summary>
    /// Details about the currently connected client/user
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public int DonorId { get; set; }
        public string PageName { get; set; }
        public bool IsActive { get; set; }
        
    }
}
