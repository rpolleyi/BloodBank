using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LifeLine.Infrastructure
{
    public class DonorNotFoundException : Exception
    {
        public DonorNotFoundException()
        : base() { }

        public DonorNotFoundException(string message)
        : base(message) { }

        public DonorNotFoundException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public DonorNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }

        public DonorNotFoundException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }

        protected DonorNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
    }
}