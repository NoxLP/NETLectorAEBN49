using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte : aRegistroBase
    {
        public RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte(string linea, int indexLinea) : base(linea, indexLinea)
        {
            int[] longitudes = AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.CabeceraDeCuenta];
            int numeroCampos = longitudes.Length;
            try
            {
                int index = 0;
                int longitud;
                string value;
                for (int i = 1; i < numeroCampos; i++)
                {
                    longitud = longitudes[i];
                    value = linea.Substring(index, longitud);
                    switch (i)
                    {
                        case 1:
                            CodigoDato = int.Parse(value);
                            break;
                        case 2:
                            ClaveDivisaOrigenMovimiento = (DivisasISOEnum)int.Parse(value);
                            break;
                        case 3:
                            value = value.Insert(longitud - 3, ",");
                            Importe = decimal.Parse(value);
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

        public int CodigoDato { get; private set; }
        public DivisasISOEnum ClaveDivisaOrigenMovimiento { get; private set; }
        public decimal Importe { get; private set; }
    }
}
