using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Exceptions
{

    [Serializable]
    public class SaldosNoCoincidenCustomException : Exception
    {
        public SaldosNoCoincidenCustomException() { }
        public SaldosNoCoincidenCustomException(string message) : base(message) { }
        public SaldosNoCoincidenCustomException(string message, Exception inner) : base(message, inner) { }
        protected SaldosNoCoincidenCustomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
