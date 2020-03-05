using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroPrincipalDeMovimientos : aRegistroBase
    {
        public RegistroPrincipalDeMovimientos(string linea, int indexLinea) : base(linea, indexLinea)
        {
            int[] longitudes = AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.PrincipalDeMovimientos];
            int numeroCampos = longitudes.Length;
            var provider = CultureInfo.InvariantCulture;
            try
            {
                int index = 6;
                int longitud;
                string value;
                for (int i = 2; i < numeroCampos; i++)
                {
                    longitud = longitudes[i];
                    value = linea.Substring(index, longitud);
                    switch (i)
                    {
                        case 2:
                            ClaveOficinaOrigen = int.Parse(value);
                            break;
                        case 3:
                            FechaOperacion = DateTime.ParseExact(value, "yyMMdd", provider);
                            break;
                        case 4:
                            FechaValor = DateTime.ParseExact(value, "yyMMdd", provider);
                            break;
                        case 5:
                            ConceptoComun = (ConceptosComunesEnum)int.Parse(value);
                            break;
                        case 6:
                            ConceptoPropio = int.Parse(value);
                            break;
                        case 7:
                            DebeHaber = (DebeHaberEnum)int.Parse(value);
                            break;
                        case 8:
                            Importe = value.RegistroImporteStringADecimal(longitud);
                            break;
                        case 9:
                            NumeroDocumento = value.Trim();
                            break;
                        case 10:
                            Referencia1 = value.Trim();
                            break;
                        case 11:
                            Referencia2 = value.Trim();
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

        public int ClaveOficinaOrigen { get; private set; }
        public DateTime FechaOperacion { get; private set; }
        public DateTime FechaValor { get; private set; }
        public ConceptosComunesEnum ConceptoComun { get; private set; }
        public int ConceptoPropio { get; private set; }
        public DebeHaberEnum DebeHaber { get; private set; }
        public decimal Importe { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string Referencia1 { get; private set; }
        public string Referencia2 { get; private set; }
    }
}
