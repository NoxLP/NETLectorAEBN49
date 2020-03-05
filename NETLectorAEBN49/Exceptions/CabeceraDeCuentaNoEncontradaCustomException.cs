using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Exceptions
{
    [Serializable]
    public class CabeceraDeCuentaNoEncontradaCustomException : Exception
    {
        public CabeceraDeCuentaNoEncontradaCustomException() { }
        public CabeceraDeCuentaNoEncontradaCustomException(string message) : base(message) { }
        public CabeceraDeCuentaNoEncontradaCustomException(string message, Exception inner) : base(message, inner) { }
        protected CabeceraDeCuentaNoEncontradaCustomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
