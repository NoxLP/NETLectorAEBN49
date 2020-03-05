using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model
{
    public enum CodigoRegistroEnum : int
    {
        None = 0,
        CabeceraDeCuenta = 11,
        PrincipalDeMovimientos = 22,
        ComplementarioDeConceptos = 23,
        ComplementarioDeInformacionEquivalenciaDeImporte = 24,
        FinDeCuenta = 33,
        FinDeFichero = 88
    }
}
