using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using System.Collections.Generic;

namespace Fronteiras.Executores
{
    public class ListarConveniosResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }
        public IEnumerable<ConvenioDTO> Convenios { get; set; }
    }
}
