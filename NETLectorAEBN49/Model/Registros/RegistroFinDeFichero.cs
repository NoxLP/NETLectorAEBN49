using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroFinDeFichero : aRegistroBase
    {
        public RegistroFinDeFichero(string linea, int indexLinea) : base(linea, indexLinea)
        {
            NumeroRegistros = int.Parse(
                linea.Substring(19, AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.FinDeFichero][2]));
        }

        public int NumeroRegistros { get; private set; }
    }
}
