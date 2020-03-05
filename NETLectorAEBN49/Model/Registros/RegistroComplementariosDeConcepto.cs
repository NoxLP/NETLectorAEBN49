using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model.Registros
{
    public class RegistroComplementariosDeConcepto : aRegistroBase
    {
        public RegistroComplementariosDeConcepto(string linea, int indexLinea) : base(linea, indexLinea)
        {
            int[] longitudes = AEBN43StaticData.LongitudesDeCamposPorRegistros[CodigoRegistroEnum.ComplementarioDeConceptos];
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
                            CodigoDato = int.Parse(value);
                            break;
                        case 2:
                            Concepto1 = value.Trim();
                            break;
                        case 3:
                            Concepto2 = value.Trim();
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
        public string Concepto1 { get; private set; }
        public string Concepto2 { get; private set; }
    }
}
