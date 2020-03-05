using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model
{
    public static class AEBN43StaticData
    {
        internal static Dictionary<CodigoRegistroEnum, int[]> LongitudesDeCamposPorRegistros = new Dictionary<CodigoRegistroEnum, int[]>()
        {
            {
                CodigoRegistroEnum.CabeceraDeCuenta,
                new int[11] 
                {
                    2,4,4,10,6,6,1,14,3,1,26
                }
            },
            {
                CodigoRegistroEnum.PrincipalDeMovimientos,
                new int[12]
                {
                    2,4,4,6,6,2,3,1,14,10,12,16
                }
            },
            {
                CodigoRegistroEnum.ComplementarioDeConceptos,
                new int[4]
                {
                    2,2,38,38
                }
            },
            {
                CodigoRegistroEnum.ComplementarioDeInformacionEquivalenciaDeImporte,
                new int[4]
                {
                    2,2,3,14
                }
            },
            {
                CodigoRegistroEnum.FinDeCuenta,
                new int[11]
                {
                    2,4,4,10,5,14,5,14,1,14,3
                }
            },
            {
                CodigoRegistroEnum.FinDeFichero,
                new int[3]
                {
                    2,18,6
                }
            }
        };

        public static CodigoRegistroEnum GetCodigoRegistro(string linea)
        {
            try
            {
                return (CodigoRegistroEnum)int.Parse(linea.Substring(0, 2));
            }
            catch (Exception e)
            {
                throw new Exceptions.ImposibleLeerCodigoDeRegistroDeLineaCustomException(
                    $"No se pudo leer el código de registro de la línea: {linea}",
                    e);
            }
        }
    }
}
