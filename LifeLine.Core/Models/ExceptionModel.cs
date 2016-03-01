using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLine.Core.Models
{
    public class ExceptionModel
    {
        public string Controller { get; set; }
        public string View { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }

    }
}
