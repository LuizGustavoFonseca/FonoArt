using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using System.Collections.Generic;

namespace Fronteiras.Executores
{
    public class ListarFonoaudiologasResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }        
        public IEnumerable<FonoaudiologaDTO> Fonoaudiologas { get; set; }
    }
}
