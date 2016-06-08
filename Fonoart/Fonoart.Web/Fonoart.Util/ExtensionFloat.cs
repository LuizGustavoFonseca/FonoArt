using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.NucleoPoliticasComerciais.Util.Extensoes
{
    public static class ExtensionFloat
    {
        public static bool EhIgual(this float valor1, float valor2, int casasDecimais)
        {
            return Math.Round(valor1, casasDecimais) == Math.Round(valor2, casasDecimais);
        }
    }
}
