using NETLectorAEBN49.Model;
using NETLectorAEBN49.Model.Registros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49
{
    public class FicheroAEBN43
    {
        public FicheroAEBN43(string rutaCompletaFichero)
        {
            if (!File.Exists(rutaCompletaFichero))
                throw new FileNotFoundException();

            RutaCompletaFicheroN43 = rutaCompletaFichero;
            ReadArchivoN43();
        }
        
        public string RutaCompletaFicheroN43 { get; private set; }
        public RegistroCabeceraDeCuenta Cabecera { get; private set; }
        public RegistroFinalDeCuenta FinDeCuenta { get; private set; }
        public RegistroFinDeFichero FinDeFichero { get; private set; }
        public List<IMovimientoBancario> MovimientosBancarios { get; private set; }

        private aRegistroBase NewRegistro(string linea, int indexLinea)
        {
            var codigo = AEBN43StaticData.GetCodigoRegistro(linea);

            switch(codigo)
            {
                case CodigoRegistroEnum.CabeceraDeCuenta:
                    return new RegistroCabeceraDeCuenta(linea, indexLinea);
                case CodigoRegistroEnum.PrincipalDeMovimientos:
                    return new RegistroPrincipalDeMovimientos(linea, indexLinea);
                case CodigoRegistroEnum.ComplementarioDeConceptos:
                    return new RegistroComplementariosDeConcepto(linea, indexLinea);
                case CodigoRegistroEnum.ComplementarioDeInformacionEquivalenciaDeImporte:
                    return new RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte(linea, indexLinea);
                case CodigoRegistroEnum.FinDeCuenta:
                    return new RegistroFinalDeCuenta(linea, indexLinea);
                case CodigoRegistroEnum.FinDeFichero:
                    return new RegistroFinDeFichero(linea, indexLinea);
                default:
                    return null;
            }
        }

        private void SetMovimientosBancarios(List<aRegistroBase> registros)
        {
            MovimientosBancarios = new List<IMovimientoBancario>();
            decimal acumulado = 0;
            RegistroPrincipalDeMovimientos currentPrincipal = null;
            RegistroComplementariosDeConcepto currentConcepto1 = null;
            List<RegistroComplementariosDeConcepto> currentComplementarios = null;
            List<RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte> currentEquivalencias = null;
            aRegistroBase currentRegistro;
            for (int i = 1; i < registros.Count - 2; i++) //no incluye cabecera ni finales de cuenta ni de fichero
            {
                currentRegistro = registros[i];

                if ((currentRegistro.CodigoDeRegistro == CodigoRegistroEnum.FinDeCuenta && i != registros.Count - 2) ||
                    (currentRegistro.CodigoDeRegistro == CodigoRegistroEnum.FinDeFichero && i != registros.Count - 1))
                {
                    throw new NotImplementedException(
                        "El programa no está preparado para leer archivos con varias cuentas bancarias al mismo tiempo. Ejecute un archivo de una cuenta bancaria cada vez.");
                }

                switch (currentRegistro.CodigoDeRegistro)
                {
                    case CodigoRegistroEnum.PrincipalDeMovimientos:
                        if (currentPrincipal != null)
                        {
                            MovimientosBancarios.Add(new MovimientoBancario(i, currentPrincipal, currentConcepto1, currentComplementarios, currentEquivalencias));
                        }

                        currentPrincipal = (RegistroPrincipalDeMovimientos)currentRegistro;
                        currentConcepto1 = null;
                        if (currentComplementarios != null && currentComplementarios.Count > 0)
                            currentComplementarios.Clear();
                        if (currentEquivalencias != null && currentEquivalencias.Count > 0)
                            currentEquivalencias.Clear();
                        acumulado = acumulado.Sum(currentPrincipal.Importe, currentPrincipal.DebeHaber);
                        break;
                    case CodigoRegistroEnum.ComplementarioDeConceptos:
                        if (currentConcepto1 == null)
                        {
                            currentConcepto1 = (RegistroComplementariosDeConcepto)currentRegistro;
                            break;
                        }

                        if (currentComplementarios == null)
                            currentComplementarios = new List<RegistroComplementariosDeConcepto>() { (RegistroComplementariosDeConcepto)currentRegistro };
                        else
                            currentComplementarios.Add((RegistroComplementariosDeConcepto)currentRegistro);

                        break;
                    case CodigoRegistroEnum.ComplementarioDeInformacionEquivalenciaDeImporte:
                        if (currentEquivalencias == null)
                        {
                            currentEquivalencias = new List<RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte>()
                                { (RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte)currentRegistro };
                        }
                        else
                            currentEquivalencias.Add((RegistroComplementarioDeInformacionDeEquivalenciaDelImporteDelApunte)currentRegistro);

                        break;
                }
            }

            if (currentPrincipal != null)
            {
                MovimientosBancarios.Add(new MovimientoBancario(registros.Count - 2, currentPrincipal, currentConcepto1, currentComplementarios, currentEquivalencias));
            }

            if (Cabecera.ImporteSaldoInicial + acumulado != FinDeCuenta.ImporteSaldoFinal)
                throw new Exceptions.SaldosNoCoincidenCustomException("Ocurrió algún error al leer el fichero N43 y el saldo final no se ajusta a la suma del saldo inicial y los movimientos bancarios contenidos en el fichero.");
        }
        private void ReadArchivoN43()
        {
            var lineas = File.ReadAllLines(RutaCompletaFicheroN43);

            if (AEBN43StaticData.GetCodigoRegistro(lineas[0]) != CodigoRegistroEnum.CabeceraDeCuenta ||
                AEBN43StaticData.GetCodigoRegistro(lineas[lineas.Length - 1]) != CodigoRegistroEnum.FinDeFichero ||
                AEBN43StaticData.GetCodigoRegistro(lineas[lineas.Length - 1]) != CodigoRegistroEnum.FinDeFichero)
                throw new Exceptions.CabeceraDeCuentaNoEncontradaCustomException();

            List<aRegistroBase> registros = new List<aRegistroBase>();
            for (int i = 0; i < lineas.Length; i++)
            {
                registros.Add(NewRegistro(lineas[i], i));
            }

            Cabecera = (RegistroCabeceraDeCuenta)registros[0];
            FinDeCuenta = (RegistroFinalDeCuenta)registros[registros.Count - 2];
            FinDeFichero = (RegistroFinDeFichero)registros[registros.Count - 1];

            SetMovimientosBancarios(registros);
        }
    }
}
