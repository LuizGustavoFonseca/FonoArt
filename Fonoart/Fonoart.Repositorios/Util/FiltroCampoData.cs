using System;

namespace Repositorios.Util
{
    public class FiltroCampoData : Filtro<DateTime>
    {
        public override DateTime Valor { get; set; }       
    }
}
