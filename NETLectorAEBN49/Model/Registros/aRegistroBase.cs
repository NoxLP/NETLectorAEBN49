using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public abstract class aRegistroBase
    {
        public aRegistroBase(string linea, int indexLinea)
        {
            CodigoDeRegistro = AEBN43StaticData.GetCodigoRegistro(linea);
            IndexLinea = indexLinea;
        }

        public CodigoRegistroEnum CodigoDeRegistro { get; private set; }
        public int IndexLinea { get; private set; }
    }
}
