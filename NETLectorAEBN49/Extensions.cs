using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLectorAEBN49
{
    public static class Extensions
    {
        public static decimal Sum(this decimal source, decimal second, NETLectorAEBN49.Model.DebeHaberEnum debeHaberEnum)
        {
            int multiplier = (((int)debeHaberEnum) * 2) - 3;
            return source + (second * multiplier);
        }
        public static decimal RegistroImporteStringADecimal(this string source, int longitud)
        {
            string value = source.Insert(longitud - 2, ",");
            return decimal.Parse(value);
        }
    }
}
