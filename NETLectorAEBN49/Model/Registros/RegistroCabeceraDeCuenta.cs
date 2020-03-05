using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroCabeceraDeCuenta : aRegistroBase
    {
        public RegistroCabeceraDeCuenta(string linea, int indexLinea) : base(linea, indexLinea)
        {
            int[] longitudes = AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.CabeceraDeCuenta];
            int numeroCampos = longitudes.Length;
            var provider = CultureInfo.InvariantCulture;
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
                            FechaInicial = DateTime.ParseExact(value, "yyMMdd", provider);
                            break;
                        case 5:
                            FechaFinal = DateTime.ParseExact(value, "yyMMdd", provider);
                            break;
                        case 6:
                            DebeHaber = (DebeHaberEnum)int.Parse(value);
                            break;
                        case 7:
                            ImporteSaldoInicial = value.RegistroImporteStringADecimal(longitud);
                            break;
                        case 8:
                            Divisa = (DivisasISOEnum)int.Parse(value);
                            break;
                        case 9:
                            Modalidad = int.Parse(value);
                            break;
                        case 10:
                            NombreAbreviado = value.Trim();
                            break;
                    }
                    index += longitud;
                }
            }
            catch(Exception e)
            {
                throw new Exceptions.ImposibleCrearRegistroException($"Imposible crear registro del tipo {CodigoDeRegistro.ToString()}", e);
            }
        }

        public int ClaveEntidad { get; private set; }
        public int ClaveOficina { get; private set; }
        public int NumeroCuenta { get; private set; }
        public DateTime FechaInicial { get; private set; }
        public DateTime FechaFinal { get; private set; }
        public DebeHaberEnum DebeHaber { get; private set; }
        public decimal ImporteSaldoInicial { get; private set; }
        public DivisasISOEnum Divisa { get; private set; }
        public int Modalidad { get; private set; }
        public string NombreAbreviado { get; private set; }
    }
}
