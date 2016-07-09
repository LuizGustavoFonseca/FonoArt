using Fronteiras.Dtos;
using System.Collections.Generic;

namespace Fonoart.Web.Models
{
    public class AtendimentoModel
    {
        public IEnumerable<FonoaudiologaDTO> Fonoaudiologas { get; set; }
        public IEnumerable<ConvenioDTO> Convenios { get; set; }
        public IEnumerable<SituacaoDTO> Situacoes { get; set; }
    }
}