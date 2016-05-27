using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Util
{
    public class FiltroCampoString : Filtro<string>
    {
        public string NomeCampo { get; set; }
        public string ValorData { get; set; }
    }
}
