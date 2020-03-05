using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroFinalDeCuenta : aRegistroBase
    {
        public RegistroFinalDeCuenta(string linea, int indexLinea) : base(linea, indexLinea)
        {
            int[] longitudes = AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.FinDeCuenta];
            int numeroCampos = longitudes.Length;
            try
            {
                int index = 2;
                int longitud;
                string value;
                for (int i = 1; i < numeroCampos; i++)
                {
                    longitud = longitudes[i];
                    value = linea.Substring(index, longitud);
                    switch (i)
                    {
                        case 1:
                            ClaveEntidad = int.Parse(value);
                            break;
                        case 2:
                            ClaveOficina = int.Parse(value);
                            break;
                        case 3:
                            NumeroCuenta = int.Parse(value);
                            break;
                        case 4:
                            NumeroApuntesDebe = int.Parse(value);
                            break;
                        case 5:
                            TotalImportesDebe = value.RegistroImporteStringADecimal(longitud);
                            break;
                        case 6:
                            NumeroApuntesHaber = int.Parse(value);
                            break;
                        case 7:
                            TotalImportesHaber = value.RegistroImporteStringADecimal(longitud);
                            break;
                        case 8:
                            CodigoSaldoFinal = (DebeHaberEnum)int.Parse(value);
                            break;
                        case 9:
                            ImporteSaldoFinal = value.RegistroImporteStringADecimal(longitud);
                            break;
                        case 10:
                            ClaveDivisa = (DivisasISOEnum)int.Parse(value);
                            break;
                    }
                    index += longitud;
                }
            }
            catch (Exception e)
            {
                throw new Exceptions.ImposibleCrearRegistroException($"Imposible crear registro del tipo {CodigoDeRegistro.ToString()}", e);
            }
        }

        public int ClaveEntidad { get; private set; }
        public int ClaveOficina { get; private set; }
        public int NumeroCuenta { get; private set; }
        public int NumeroApuntesDebe { get; private set; }
        public decimal TotalImportesDebe { get; private set; }
        public int NumeroApuntesHaber { get; private set; }
        public decimal TotalImportesHaber { get; private set; }
        public DebeHaberEnum CodigoSaldoFinal { get; private set; }
        public decimal ImporteSaldoFinal { get; private set; }
        public DivisasISOEnum ClaveDivisa { get; private set; }
    }
}
