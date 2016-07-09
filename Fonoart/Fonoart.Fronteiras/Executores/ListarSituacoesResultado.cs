using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using System.Collections.Generic;

namespace Fronteiras.Executores
{
    public class ListarSituacoesResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }
        public IEnumerable<SituacaoDTO> Situacoes { get; set; }
    }
}
