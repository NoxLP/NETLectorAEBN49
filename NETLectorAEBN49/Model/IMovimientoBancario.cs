using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49.Model
{
    public interface IMovimientoBancario
    {
        int IndexInFile { get; }
        string Concepto { get; }
        string[] ConceptosComplementarios { get; }
        DateTime Fecha { get; }
        decimal Importe { get; }
        DebeHaberEnum DebeHaber { get; }
        bool IsDevolucion { get; }
    }
}
