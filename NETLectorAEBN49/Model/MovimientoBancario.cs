using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETLectorAEBN49.Model.Registros;

namespace NETLectorAEBN49.Model
{
    public class MovimientoBancario : IMovimientoBancario, IEquatable<MovimientoBancario>
    {
        public MovimientoBancario(
            int index,
            RegistroPrincipalDeMovimientos registroPrincipal, 
            RegistroComplementariosDeConcepto registroConcepto, 
            IEnumerable<RegistroComplementariosDeConcepto> registroConceptosComplementarios = null, 
            IEnumerable<RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte> registroComplementariosEquivalenciaImporte = null)
        {
            IndexInFile = index;
            RegistroPrincipal = registroPrincipal;
            RegistroConcepto = registroConcepto;
            RegistroConceptosComplementarios = registroConceptosComplementarios;
            RegistroComplementariosEquivalenciaImporte = registroComplementariosEquivalenciaImporte;

            Concepto = registroConcepto.Concepto1 + registroConcepto.Concepto2;
            if (registroConceptosComplementarios != null)
            {
                ConceptosComplementarios = registroConceptosComplementarios.
                    Select(r => r.Concepto1 + r.Concepto2)
                    .ToArray();
            }
            Fecha = registroPrincipal.FechaOperacion;
            Importe = (registroPrincipal.DebeHaber == DebeHaberEnum.Debe ? registroPrincipal.Importe : registroPrincipal.Importe * -1);
            DebeHaber = registroPrincipal.DebeHaber;
            if (registroPrincipal.ConceptoComun == ConceptosComunesEnum.DEVOLUCIONES_IMPAGADOS)
                IsDevolucion = true;
        }

        public int IndexInFile { get; private set; }
        public RegistroPrincipalDeMovimientos RegistroPrincipal { get; private set; }
        public RegistroComplementariosDeConcepto RegistroConcepto { get; private set; }
        public IEnumerable<RegistroComplementariosDeConcepto> RegistroConceptosComplementarios { get; private set; }
        public IEnumerable<RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte> RegistroComplementariosEquivalenciaImporte { get; private set; }

        public string Concepto { get; private set; }
        public string[] ConceptosComplementarios { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Importe { get; private set; }
        public DebeHaberEnum DebeHaber { get; private set; }
        public bool IsDevolucion { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as MovimientoBancario;
            if (other == null)
                return false;
            return this.Equals(other);
        }
        public bool Equals(MovimientoBancario other)
        {
            if (other == null)
                return false;
            return IndexInFile == other.IndexInFile;
        }
        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            hash += (IndexInFile.GetHashCode() * 7);
            return hash;
        }
    }
}
