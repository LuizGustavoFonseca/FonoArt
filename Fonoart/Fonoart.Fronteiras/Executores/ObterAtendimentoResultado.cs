using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;

namespace Fronteiras.Executores
{
    public class ObterAtendimentoResultado : IResultado
    {
        public EstadoResultado Estado { get; }
        
        public AtendimentoDTO Atendimento { get; set; }
    }
}
