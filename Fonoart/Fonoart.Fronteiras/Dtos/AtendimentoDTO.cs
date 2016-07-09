using Fonoart.Util.Enum;
using System;

namespace Fronteiras.Dtos
{
    public class AtendimentoDTO
    {
        public string CodigoAtendimento { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string CodigoPaciente { get; set; }
        public string CpfFonoaudiologa { get; set; }
        public int IdSituacao { get; set; }      
        public TipoAtendimento TipoAtendimento { get; set; }  

        public PacienteDTO Paciente { get; set; }
        public FonoaudiologaDTO Fonoaudiologa { get; set; }
        public SituacaoDTO Situacao { get; set; }
    }
}
