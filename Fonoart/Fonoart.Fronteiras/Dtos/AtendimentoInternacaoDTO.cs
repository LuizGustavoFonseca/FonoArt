using System;

namespace Fronteiras.Dtos
{
    public class AtendimentoInternacaoDTO : AtendimentoDTO
    {
        public string Quarto { get; set; }
        public DateTime DataInternacao { get; set; }
    }
}
