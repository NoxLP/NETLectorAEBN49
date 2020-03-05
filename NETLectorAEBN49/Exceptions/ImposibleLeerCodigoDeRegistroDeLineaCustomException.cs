using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Exceptions
{

    [Serializable]
    public class ImposibleLeerCodigoDeRegistroDeLineaCustomException : Exception
    {
        public ImposibleLeerCodigoDeRegistroDeLineaCustomException() { }
        public ImposibleLeerCodigoDeRegistroDeLineaCustomException(string message) : base(message) { }
        public ImposibleLeerCodigoDeRegistroDeLineaCustomException(string message, Exception inner) : base(message, inner) { }
        protected ImposibleLeerCodigoDeRegistroDeLineaCustomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
