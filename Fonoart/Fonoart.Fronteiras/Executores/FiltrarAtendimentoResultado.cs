using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using System.Collections.Generic;

namespace Fronteiras.Executores
{
    public class FiltrarAtendimentoResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }
        public IEnumerable<AtendimentoInternacaoDTO> AtendimentosInternacao { get; set; }
        public IEnumerable<AtendimentoAmbulatorialDTO> AtendimentosAmbulatoriais { get; set; }
    }
}
