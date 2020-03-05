using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Exceptions
{

    [Serializable]
    public class ImposibleCrearRegistroException : Exception
    {
        public ImposibleCrearRegistroException() { }
        public ImposibleCrearRegistroException(string message) : base(message) { }
        public ImposibleCrearRegistroException(string message, Exception inner) : base(message, inner) { }
        protected ImposibleCrearRegistroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
